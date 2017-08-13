using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Assist
{
    class UnusedParametersAnalyzer
    {
        // You can change these strings in the Resources.resx file. If you do not want your analyzer to be localize-able, you can use regular strings for Title and MessageFormat.
        // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Localizing%20Analyzers.md for more on localization
        static readonly LocalizableString _Title = new LocalizableResourceString(
            nameOfLocalizableResource: nameof(Resources.UnusedParameterTitle),
            resourceManager: Resources.ResourceManager,
            resourceSource: typeof(Resources));

        static readonly LocalizableString _MessageFormat = new LocalizableResourceString(
            nameOfLocalizableResource: nameof(Resources.UnusedParameterMessageFormat),
            resourceManager: Resources.ResourceManager,
            resourceSource: typeof(Resources));

        static readonly LocalizableString _Description = new LocalizableResourceString(
            nameOfLocalizableResource: nameof(Resources.UnusedParameterDescription),
            resourceManager: Resources.ResourceManager,
            resourceSource: typeof(Resources));

        static readonly string _Category = "Syntax";

        public static DiagnosticDescriptor DiagnosticRule = new DiagnosticDescriptor(
            id: Constants.DiagnosticId,
            title: _Title,
            messageFormat: _MessageFormat,
            category: _Category,
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: _Description);

        public UnusedParametersAnalyzer(IMethodSymbol methodSymbol)
        {
            _unusedParameters = new HashSet<IParameterSymbol>(methodSymbol.Parameters);
        }

        readonly HashSet<IParameterSymbol> _unusedParameters;

        IEnumerable<string> _GetUnusedParameterNames() => _unusedParameters.Select(p => p.Name);

        public void AnalyzeSyntaxNode(SyntaxNodeAnalysisContext context)
        {
            if (_unusedParameters.Count == 0) { return; }

            var identifier = (IdentifierNameSyntax)context.Node;
            if (!_GetUnusedParameterNames().Contains(identifier.Identifier.ValueText)) { return; }

            var parameter = context.SemanticModel.GetSymbolInfo(identifier, context.CancellationToken).Symbol as IParameterSymbol;
            if (parameter == null) { return; }

            if (_unusedParameters.Contains(parameter))
            {
                _unusedParameters.Remove(parameter);
            }
        }

        public void CodeBlockEndAction(CodeBlockAnalysisContext context)
        {

            foreach (var parameter in _unusedParameters)
            {
                var location = parameter.Locations.FirstOrDefault();

                var diagnostic = Diagnostic.Create(
                    DiagnosticRule,
                    location,
                    parameter.Name, parameter.ContainingSymbol.Name);

                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}
