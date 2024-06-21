
namespace scripts

module math =
    let buildingPrice (baseCost: float) (count: float) : int = 
        int (baseCost * (1.15 ** (count-float 1)))


module strings = 
    let removeSuffix (str: string) (suffix: string) : string =
        if str.EndsWith(suffix) then
            let x = str.[..str.Length-suffix.Length-1]
            x
        else
            str



