function randomChance(quarters){
    var count = 0;
    var random = 0;

    console.log ("You have", quarters, "quarters. You put 1 quarter in the slot machine.");

    while (quarters > 0){

        quarters--;
        var random = Math.floor((Math.random() *100) + 1);

        if(random == 33){
            var quarters = quarters + Math.trunc(Math.random() * 50)+51;
            console.log("WINNER!!! You now have", quarters,"quarters.");
        }

        else{
            console.log("You lost... You now have", quarters,"quarters.");
        }
    }

    if(quarters == 0){
        console.log("Game Over. You have run out of quarters.");
        return 0;
    }
}

randomChance(100);