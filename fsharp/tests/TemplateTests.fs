namespace UnitTests

open System

open NUnit.Framework

open Template

[<TestFixture>]
type TemplateTests () =

    [<Test>]
    member this.Method_Scenario_ExpectedBehaviour() =
        Assert.AreEqual(42, 21);

