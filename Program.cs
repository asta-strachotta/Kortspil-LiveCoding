Card[] deck = AssignCards(20);

int maxHearts = 0;
int maxClubs = 0;
int maxSpades = 0;
int maxDiamonds = 0;

for(int i = 0; i < deck.Length; i++){
    Console.WriteLine(deck[i].suit + " " + deck[i].value);
    
    switch(deck[i].suit){
        case Suit.Hearts:
            if(deck[i].value > maxHearts){
                maxHearts = deck[i].value;
            }
            break;
        case Suit.Diamonds:
            if(deck[i].value > maxDiamonds){
                maxDiamonds = deck[i].value;
            }
            break;
        case Suit.Clubs:
            if(deck[i].value > maxClubs){
                maxClubs = deck[i].value;
            }
            break;
        case Suit.Spades:
            if(deck[i].value > maxSpades){
                maxSpades = deck[i].value;
            }
            break;

        }
    }

Console.WriteLine("\nMax for each suit: \n" + 
					"Hearts: " + maxHearts + "\n" + 
					"Diamonds: " + maxDiamonds + "\n" + 
					"Clubs: " + maxClubs + "\n" + 
					"Spades: " + maxSpades);






//helpers
static int[] AssignNumbers(int num){
    int[] arr = new int[num];
    Random rnd = new Random();
    for(int i = 0; i < arr.Length; i++){
        arr[i] = rnd.Next(1,51);
    }
    return arr;
}


static Card[] AssignCards(int numOfCards){
    Card[] deck = new Card[numOfCards];
    Random rnd = new Random();

    Card[] tempDeck = new Card[52];

    for(int i = 0; i < tempDeck.Length; i++){
    	tempDeck[i].value = i % 13 + 1;
    	tempDeck[i].suit = (Suit)(i % 4);
    }

    for(int i = 0; i < deck.Length; i++){
    	int next = rnd.Next(0,52);
    	if(!ContainsCard(deck, tempDeck[next])){
    		deck[i].value = tempDeck[next].value;
    		deck[i].suit = tempDeck[next].suit;
    	}else{
    		i--;
    	}
    }
    return deck;
}

static bool ContainsCard(Card[] deck, Card card){
	for(int i = 0; i < deck.Length; i++){
		if((deck[i].value == card.value) && (deck[i].suit == card.suit)){
			return true;
		}
	}
	return false;
}



enum Suit{
    Hearts,
    Diamonds,
    Clubs,
    Spades
}

struct Card{
    public int value;
    public Suit suit;
}