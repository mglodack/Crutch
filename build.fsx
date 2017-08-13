#r @"._fake/packages/FAKE/tools/FakeLib.dll"
#r @"._fake/packages/FSharp.FakeTargets/tools/FSharp.FakeTargets.dll"


open Fake

datNET.Targets.initialize (fun parameters ->
  { parameters with
      AssemblyInfoFilePaths = [ "SharedAssemblyInfo.cs" ]
  }
)

RunTargetOrDefault "List"
