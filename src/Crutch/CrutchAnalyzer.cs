using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;

namespace Crutch
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class CrutchAnalyzer : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        {
            get
            {
                return ImmutableArray.Create(
                    InvalidPropertyAssignmentAnalyzer.DiagnosticRule,
                    UnusedParametersAnalyzer.DiagnosticRule);
            }
        }

        public override void Initialize(AnalysisContext context)
        {
            context
                .RegisterSyntaxNodeAction(
                    action:      new InvalidPropertyAssignmentAnalyzer().AnalyzeSyntaxNode,
                    syntaxKinds: SyntaxKind.SimpleAssignmentExpression);

            context.RegisterCodeBlockStartAction<SyntaxKind>(startCodeBlockContext =>
            {
                if (startCodeBlockContext.OwningSymbol.Kind != SymbolKind.Method) { return; }

                var methodSymbol = (IMethodSymbol)startCodeBlockContext.OwningSymbol;
                if (methodSymbol.Parameters.IsEmpty) { return; }

                var codeBlockAnalyzer = new UnusedParametersAnalyzer(methodSymbol);

                startCodeBlockContext
                    .RegisterSyntaxNodeAction(
                        action:      codeBlockAnalyzer.AnalyzeSyntaxNode,
                        syntaxKinds: SyntaxKind.IdentifierName);

                startCodeBlockContext
                    .RegisterCodeBlockEndAction(
                        action: codeBlockAnalyzer.CodeBlockEndAction);
            });
        }
    }
}
