using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Assist
{
    class InvalidPropertyAssignmentAnalyzer
    {
        // You can change these strings in the Resources.resx file. If you do not want your analyzer to be localize-able, you can use regular strings for Title and MessageFormat.
        // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Localizing%20Analyzers.md for more on localization
        static readonly LocalizableString _Title = new LocalizableResourceString(
            nameOfLocalizableResource: nameof(Resources.InvalidPropertyAssignmentTitle),
            resourceManager: Resources.ResourceManager,
            resourceSource: typeof(Resources));

        static readonly LocalizableString _MessageFormat = new LocalizableResourceString(
            nameOfLocalizableResource: nameof(Resources.InvalidPropertyAssignmentMessageFormat),
            resourceManager: Resources.ResourceManager,
            resourceSource: typeof(Resources));

        static readonly LocalizableString _Description = new LocalizableResourceString(
            nameOfLocalizableResource: nameof(Resources.InvalidPropertyAssignmentDescription),
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

        public void AnalyzeSyntaxNode(SyntaxNodeAnalysisContext context)
        {
            var simpleAssignmentExpression = (AssignmentExpressionSyntax)context.Node;

            var leftPropertyName = simpleAssignmentExpression.Left.ToString();
            var rightPropertyName = simpleAssignmentExpression.Right.ToString();

            if (leftPropertyName == rightPropertyName)
            {
                var diagnostic = Diagnostic.Create(
                    descriptor: DiagnosticRule,
                    location: simpleAssignmentExpression.GetLocation(),
                    messageArgs: leftPropertyName);

                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}
