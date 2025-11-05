using System;
using System.ComponentModel;

class Card {
    public int rank;
    public char suit;
    
    public Card(string s) {
        switch (s[0]) {
            case 'A':
                rank = 1;
                break;
            case 'K':
                rank = 13;
                break;
            case 'Q':
                rank = 12;
                break;
            case 'J':
                rank = 11;
                break;
            default:
                if (char.IsDigit(s[0])) {
                    rank = int.Parse(s.Substring(0, s.Length - 1));
                }
                break;
        }
        suit = s[s.Length - 1];
    }
}


class Hand {
    public Card[] cards = new Card[5];
    
    public Hand(string s) {
        string[] cardStrings = s.Split(' ');
        for (int i = 0; i < 5; i++) {
            cards[i] = new Card(cardStrings[i]);
        }
        Array.Sort(cards, (a, b) => b.rank.CompareTo(a.rank)); // Sorting cards in descending order of rank
    }
    
    private int GetRankCount(int rank) {
        int count = 0;
        foreach (Card card in cards) {
            if (card.rank == rank) {
                count++;
            }
        }
        return count;
    }

    public int GetMostFrequentRank() {
        int maxCount = 0;
        int mostFrequentRank = 0;
        for (int i = 1; i <= 13; i++) {
            int count = GetRankCount(i);
            if (count > maxCount || (count == maxCount && i > mostFrequentRank)) {
                maxCount = count;
                mostFrequentRank = i;
            }
        }
        return mostFrequentRank;
    }
    public int GetLargestElement() {
        int largest = cards[0].rank;
        for (int i = 1; i < cards.Length; i++) {
            if (cards[i].rank > largest  || cards[i].rank == 1) {
                largest = cards[i].rank;
                if(cards[i].rank == 1){break;}
            }
        }
        return largest;
    }
    
    public int compare(Hand h) {
        // Check for four of a kind
        int most = GetMostFrequentRank();
        int most1 = h.GetMostFrequentRank();
        if (GetRankCount(most) == 4 && h.GetRankCount(most1) != 4) {
            return 1;
        }
        if (GetRankCount(most) != 4 && h.GetRankCount(most1) == 4) {
            return -1;
        }
        if (GetRankCount(most) == 4 && h.GetRankCount(most1) == 4) {
            int thisMostFrequentRank = GetMostFrequentRank();
            int otherMostFrequentRank = h.GetMostFrequentRank();
            // Compare the most frequent ranks
            if (thisMostFrequentRank > otherMostFrequentRank || thisMostFrequentRank == 1) {
                return 1;
            } else if (thisMostFrequentRank < otherMostFrequentRank) {
                return -1;
            }
            else {return 0;}
        }

        // Check for three of a kind
        if (GetRankCount(most) == 3 && h.GetRankCount(most1) != 3) {
            return 1;
        }
        if (GetRankCount(most) != 3 && h.GetRankCount(most1) == 3) {
            return -1;
        }
        if (GetRankCount(most) == 3 && h.GetRankCount(most1) == 3) {
            int thisMostFrequentRank = GetMostFrequentRank();
            int otherMostFrequentRank = h.GetMostFrequentRank();
            // Compare the most frequent ranks
            if (thisMostFrequentRank > otherMostFrequentRank) {
                return 1;
            } else if (thisMostFrequentRank < otherMostFrequentRank  || thisMostFrequentRank == 1) {
                return -1;
            }
            else {return 0;}
        }
        
        // Check for one pair
        if (GetRankCount(most) == 2 && h.GetRankCount(most1) != 2) {
            return 1;
        }
        if (GetRankCount(most) != 2 && h.GetRankCount(most1) == 2) {
            return -1;
        }
        if (GetRankCount(most) == 2 && h.GetRankCount(most1) == 2) {
            int thisMostFrequentRank = GetMostFrequentRank();
            int otherMostFrequentRank = h.GetMostFrequentRank();
            // Compare the most frequent ranks
            if (thisMostFrequentRank > otherMostFrequentRank) {
                return 1;
            } else if (thisMostFrequentRank < otherMostFrequentRank  || thisMostFrequentRank == 1) {
                return -1;
            }
            else {return 0;}
        }
        else{
            int largest = GetLargestElement();
            int secondLargest = h.GetLargestElement();
            if (largest > secondLargest  || largest == 1) {return 1;} 
            else if (largest < secondLargest) {return -1;}
        }
        
        return 0; // Hands are equal
    }
}