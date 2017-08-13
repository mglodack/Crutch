#r @"._fake/packages/FAKE/tools/FakeLib.dll"
#r @"._fake/packages/FSharp.FakeTargets/tools/FSharp.FakeTargets.dll"


open Fake

datNET.Targets.initialize (fun parameters ->
  { parameters with
      AssemblyInfoFilePaths = [ "SharedAssemblyInfo.cs" ]
  }
)

Target "RestorePackages" (fun _ ->
  "Crutch.sln"
  |> RestoreMSSolutionPackages (fun p -> p)
)

"MSBuild" <== [ "RestorePackages" ]

RunTargetOrDefault "List"
