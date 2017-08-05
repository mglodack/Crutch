using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Assist
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class AssistAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "Assist";

        // You can change these strings in the Resources.resx file. If you do not want your analyzer to be localize-able, you can use regular strings for Title and MessageFormat.
        // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Localizing%20Analyzers.md for more on localization
        private static readonly LocalizableString Title = new LocalizableResourceString(
            nameOfLocalizableResource: nameof(Resources.AnalyzerTitle),
            resourceManager: Resources.ResourceManager,
            resourceSource: typeof(Resources));

        private static readonly LocalizableString MessageFormat = new LocalizableResourceString(
            nameOfLocalizableResource: nameof(Resources.AnalyzerMessageFormat),
            resourceManager: Resources.ResourceManager,
            resourceSource: typeof(Resources));

        private static readonly LocalizableString Description = new LocalizableResourceString(
            nameOfLocalizableResource: nameof(Resources.AnalyzerDescription),
            resourceManager: Resources.ResourceManager,
            resourceSource: typeof(Resources));

        private const string Category = "Syntax";

        private static DiagnosticDescriptor Rule = new DiagnosticDescriptor(
            id: DiagnosticId,
            title: Title,
            messageFormat: MessageFormat,
            category: Category,
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public override void Initialize(AnalysisContext context)
        {
            // TODO: Consider registering other actions that act on syntax instead of or in addition to symbols
            // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Analyzer%20Actions%20Semantics.md for more information
            //context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.NamedType);

            context.RegisterSyntaxNodeAction(_AnalyzeSyntaxNode, SyntaxKind.SimpleAssignmentExpression);
        }

        void _AnalyzeSyntaxNode(SyntaxNodeAnalysisContext analysisContext)
        {
            var simpleAssignmentExpression = (AssignmentExpressionSyntax)analysisContext.Node;

            var leftPropertyName = simpleAssignmentExpression.Left.ToString();
            var rightPropertyName = simpleAssignmentExpression.Right.ToString();

            if (leftPropertyName == rightPropertyName)
            {
                var diagnostic = Diagnostic.Create(
                     descriptor: Rule,
                    location: simpleAssignmentExpression.GetLocation(),
                    messageArgs: leftPropertyName);

                analysisContext.ReportDiagnostic(diagnostic);
            }
        }
    }
}
