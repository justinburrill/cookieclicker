namespace Tests 
open System
open Xunit


module MathTests = 
    [<Fact>]
    let ``Test building prices`` () =
        Assert.Equal(scripts.math.buildingPrice 15 0,15)
        Assert.Equal(scripts.math.buildingPrice 15 1,18)
        
        
            
