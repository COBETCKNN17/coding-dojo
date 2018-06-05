function Deck() {
    this.cards = [];

    function Card(rank, suit, value) {
        this.rank = rank;
        this.suit = suit;
        this.value = value;
    }

    var suits = ["Spade", "Club", "Diamond", "Heart"];
    var ranks = ["Ace", 2, 3, 4, 5, 6, 7, 8, 9, 10, "Jack", "Queen", "King"]

    this.checkCards = function () {
        for (var card of this.cards) {
            console.log(card);
        }
    }
    this.shuffle = function () {
        for (var card in this.cards) {
            var idx = Math.floor(Math.random() * (this.cards.length - 1))
            var temp = this.cards[cards];
            this.cards[card] = this.cards[idx];
            this.cards[idx] = temp;

        }
    }
    this.reset = function() {
        for (var suit of suits) {
            var val = 1;
            for (var rank of ranks) {
                var card = new Card(rank, suit, val);
                val++;
                this.cards.push(card)
            }
        }
    }
    this.deal = function(){
        return this.cards.pop();        
    }

    this.reset();
}

function Player(name){
    this.name = name;
    this.hand = [];
    this.deck = deck;
    this.draw = fucntion(){
        this.hand.push(this.deck.deal())
    }
    this.discard = function(){
        this.hand.pop();
    }
}


var deck1 = new Deck();
deck1.checkCards();
deck1.shuffle();
deck1.deal();