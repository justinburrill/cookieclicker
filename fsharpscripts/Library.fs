
namespace scripts

module math =
    let buildingPrice (baseCost: float) (count: float) : float = 
        (baseCost * 1.15) ** count
