function birthdayCountdown(){

    var daysUntilMyBirthday = 60;

    while (daysUntilMyBirthday >= 0){
        if (daysUntilMyBirthday >= 30){
            console.log(daysUntilMyBirthday, "days until my birthday. Such a long time... :(");
        }
        if (daysUntilMyBirthday < 30 && daysUntilMyBirthday > 5){
            console.log(daysUntilMyBirthday, "days until my birthday! Getting closer!");
        }
        if (daysUntilMyBirthday <= 5){
            console.log(daysUntilMyBirthday, "DAYS UNTIL MY BIRTHDAY!");
        }
        if (daysUntilMyBirthday == 0){
            console.log("♪ღ♪*•.¸¸¸.•*¨¨*•.¸¸¸.•*•♪ღ♪•*♪ღ♪ ░H░A░P░P░Y░ B░I░R░T░H░D░A░Y░ ♪ღ♪*•♪ღ♪*•.¸¸¸.•*¨¨*•.¸¸¸.•*•♪ღ♪•«");
        }
    daysUntilMyBirthday--;
    }
}

birthdayCountdown();