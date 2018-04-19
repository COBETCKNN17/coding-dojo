function forAFewBillion(){
    var rewardPennies = 1;

    for (var days = 2; days < 30; days++){
        var rewardPennies = rewardPennies*2;
        }
    
    var rewardDollars = rewardPennies/100;

    console.log("Reward in pennies:", rewardPennies);
    console.log("Reward in dollars:", "$"+rewardDollars);

}

forAFewBillion();

function daysTo10k(){
    var rewardPennies = 1;

    for (var days = 2; days < 30; days++){
        var rewardPennies = rewardPennies*2;
        var rewardDollars = rewardPennies/100;
        
        if(rewardDollars >= 10000){
            console.log("Days to get to $10,000:", days);
            break;
        }
    }
}

daysTo10k();

function daysTo1Billion(){
    var rewardPennies = 1;

    for (var days = 2; days < 100; days++){
        var rewardPennies = rewardPennies*2;
        var rewardDollars = rewardPennies/100;
        
        if(rewardDollars >= 1000000000){
            console.log("Days to get to $1,000,000,000:", days);
            break;
        }
    }
}

daysTo1Billion();