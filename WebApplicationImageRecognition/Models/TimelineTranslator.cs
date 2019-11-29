using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationImageRecognition.Models
{
    public class TimelineTranslator
    {
        public Dictionary<string, string> TimelineSentences { get; set; }

        public TimelineTranslator()
        {
            TimelineSentences = new Dictionary<string, string>();
            TimelineSentences.Add("Alice's Adventures in Wonderland", "Alice i Eventyrland");
            TimelineSentences.Add("First Armed Daylight Bank Robbery", "Første bevæbnede bankrøveri ved højlys dag");
            TimelineSentences.Add("The 1st 45 rpm Record", "Den første 45 omgange i minuttet plade");
            TimelineSentences.Add("The 1st Appearance of a Flying Saucer", "Den første forekomst af en flyvende tallerken");
            TimelineSentences.Add("The 1st Appearance of a Superhero", "Den første forekomst af en superhelt");
            TimelineSentences.Add("The 1st Appearance of Frankenstein's Monster", "Den første forekomst af Frankensteins monster");
            TimelineSentences.Add("The 1st Appearance of Sherlock Holmes", "Den første forekomst af Sherlock Holmes");
            TimelineSentences.Add("The 1st Appearance of the Tramp", "Den første forekomst af Tramp (spillet af Charlie Chaplin)");
            TimelineSentences.Add("The 1st Appearance of the Yeti", "Den første forekomst af den afskyelige snemand");
            TimelineSentences.Add("The 1st Exploration of Mars", "Den første udforskning af Mars");
            TimelineSentences.Add("The 1st Flight of a Space Shuttle", "Den første flyvning af rumfærgen");
            TimelineSentences.Add("The 1st Man in Space", "Det første menneske i rummet");
            TimelineSentences.Add("The 1st Report of the Loch Ness Monster", "Den første beretning om Loch Ness monstret");
            TimelineSentences.Add("The 9th Symphony", "Den 9. Symfoni");
            TimelineSentences.Add("The Appearance of Bees", "Forekomsten af bier");
            TimelineSentences.Add("The Carving of the Rosetta Stone", "Udskæring af Rosettestenen");
            TimelineSentences.Add("The Colossus of Rhodes", "Kolossen på Rhodos");
            TimelineSentences.Add("The Construction of the Trojan Horse", "Konstruktion af den trojanske hest");
            TimelineSentences.Add("The Discovery of Machu Pichu", "Opdagelsen af Machu Picchu");
            TimelineSentences.Add("The Discovery of the Ancient City of Petra", "Opdagelsen af den gamle by Petra");
            TimelineSentences.Add("The Discovery of the City of Palenque", "Opdagelsen af byen Palenque");
            TimelineSentences.Add("The Discovery of the Wreck of the Titanic", "Opdagelsen af Titanics vrag");
            TimelineSentences.Add("The Domestication of Cattle", "Domesticering/tæmning af kvæg");
            TimelineSentences.Add("The Domestication of Sheep", "Domesticering/tæmning af får");
            TimelineSentences.Add("The Domestication of the Cat", "Domesticering/tæmning af katten");
            TimelineSentences.Add("The Fable of The Crow and the Fox", "Fablen om ræven og kragen");
            TimelineSentences.Add("The Founding of the First Village", "Stiftelsen af den første landsby");
            TimelineSentences.Add("The Four Seasons", "De fire årstider");
            TimelineSentences.Add("The Illiad and the Odyssey", "Iliaden og Odysseen");
            TimelineSentences.Add("The Inauguration of the Colosseum", "Indvielsen af Colosseum");
            TimelineSentences.Add("The Introduction of the Clementine", "Introduktionen af klementinen");
            TimelineSentences.Add("The Invention of Binoculars", "Opfindelsen af kikkerten");
            TimelineSentences.Add("The Invention of Camembert", "Opfindelsen af Camembert-osten");
            TimelineSentences.Add("The Invention of Canning", "Opfindelsen af konservesdåsen/konservesflasken");
            TimelineSentences.Add("The Invention of Chess", "Opfindelsen af skak");
            TimelineSentences.Add("The Invention of Corn Flakes", "Opfindelsen af Corn Flakes");
            TimelineSentences.Add("The Invention of Currency", "Opfindelsen af valuta/møntenhed");
            TimelineSentences.Add("The Invention of Fencing", "Opfindelsen af fægtning");
            TimelineSentences.Add("The Invention of Football", "Opfindelsen af fodbold");
            TimelineSentences.Add("The Invention of Glass", "Opfindelsen af glas");
            TimelineSentences.Add("The Invention of GPS", "Opfindelsen af GPS");
            TimelineSentences.Add("The Invention of Hip-Hop", "Opfindelsen af Hip-Hop");
            TimelineSentences.Add("The Invention of Hypnotism", "Opfindelsen af hypnose");
            TimelineSentences.Add("The Invention of Instant Coffee", "Opfindelsen af instant kaffe/pulverkaffe");
            TimelineSentences.Add("The Invention of Parchment", "Opfindelsen af pergament");
            TimelineSentences.Add("The Invention of Post-It", "Opfindelsen af Post-It sedler");
            TimelineSentences.Add("The Invention of Shampoo", "Opfindelsen af shampoo");
            TimelineSentences.Add("The Invention of Soap", "Opfindelsen af sæbe");
            TimelineSentences.Add("The Invention of Sudoku", "Opfindelsen af Sudoku");
            TimelineSentences.Add("The Invention of Sunglasses", "Opfindelsen af solbriller");
            TimelineSentences.Add("The Invention of the Alarm Clock", "Opfindelsen af vækkeuret");
            TimelineSentences.Add("The Invention of the Automobile", "Opfindelsen af automobilen");
            TimelineSentences.Add("The Invention of the Camera", "Opfindelsen af kameraet");
            TimelineSentences.Add("The Invention of the Chronometer", "Opfindelsen af kronometeret");
            TimelineSentences.Add("The Invention of the Coffee Maker", "Opfindelsen af kaffemaskinen");
            TimelineSentences.Add("The Invention of the Comic Strip", "Opfindelsen af tegneserien");
            TimelineSentences.Add("The Invention of the Crossaint", "Opfindelsen af crossaint");
            TimelineSentences.Add("The Invention of the Crossword Puzzle", "Opfindelsen af kryds og tværs");
            TimelineSentences.Add("The Invention of the Die", "Opfindelsen af terningen");
            TimelineSentences.Add("The Invention of the Dishwasher", "Opfindelsen af opvaskemaskinen");
            TimelineSentences.Add("The Invention of the Electric Guitar", "Opfindelsen af den elektriske guitar");
            TimelineSentences.Add("The Invention of the Electric Iron", "Opfindelsen af det elektriske strygejern");
            TimelineSentences.Add("The Invention of the Electric Razor", "Opfindelsen af den elektriske barbermaskine");
            TimelineSentences.Add("The Invention of the Electric Washing Machine", "Opfindelsen af den elektriske vaskemaskine");
            TimelineSentences.Add("The Invention of the Flute", "Opfindelsen af fløjten");
            TimelineSentences.Add("The Invention of the Folding Umbrella", "Opfindelsen af foldeparaplyen");
            TimelineSentences.Add("The Invention of the Fork", "Opfindelsen af gaflen");
            TimelineSentences.Add("The Invention of the French Fry", "Opfindelsen af pommes frites");
            TimelineSentences.Add("The Invention of the Garbage Can", "Opfindelsen af skraldespanden");
            TimelineSentences.Add("The Invention of the Gas Lighter", "Opfindelsen af gaslighteren");
            TimelineSentences.Add("The Invention of the Glass Bottle", "Opfindelsen af glasflasken");
            TimelineSentences.Add("The Invention of the Hairdryer", "Opfindelsen af hårtørren");
            TimelineSentences.Add("The Invention of the Helicopter", "Opfindelsen af helikopteren");
            TimelineSentences.Add("The Invention of the Ink Pen", "Opfindelsen af blækpennen");
            TimelineSentences.Add("The Invention of the Key", "Opfindelsen af nøglen");
            TimelineSentences.Add("The Invention of the Mailbox", "Opfindelsen af postkassen");
            TimelineSentences.Add("The Invention of the Mechanical Washing Machine", "Opfindelsen af den mekaniske opvaskemaskine");
            TimelineSentences.Add("The Invention of the Microwave Oven", "Opfindelsen af mikrobølgeovnen");
            TimelineSentences.Add("The Invention of the Oil Lamp", "Opfindelsen af olielampen");
            TimelineSentences.Add("The Invention of the Pencil Sharpener", "Opfindelsen af blyantspidseren");
            TimelineSentences.Add("The Invention of the Plastic Bottle", "Opfindelsen af plastikflasken");
            TimelineSentences.Add("The Invention of the Playing Card", "Opfindelsen af spillekortet");
            TimelineSentences.Add("The Invention of the Pneumatic Drill", "Opfindelsen af den pneumatiske boremaskine");
            TimelineSentences.Add("The Invention of the Pocketbook", "Opfindelsen af lommebogen");
            TimelineSentences.Add("The Invention of the Portable Phone", "Opfindelsen af den bærbare telefon");
            TimelineSentences.Add("The Invention of the Refrigerator", "Opfindelsen af køleskabet");
            TimelineSentences.Add("The Invention of the Safety Razor", "Opfindelsen af barberskraberen");
            TimelineSentences.Add("The Invention of the Sandwich", "Opfindelsen af sandwichen");
            TimelineSentences.Add("The Invention of the Seaplane", "Opfindelsen af vandflyvemaskinen");
            TimelineSentences.Add("The Invention of the Spray Can", "Opfindelsen af spraydåsen");
            TimelineSentences.Add("The Invention of the Sundial", "Opfindelsen af solskiven");
            TimelineSentences.Add("The Invention of the Table Knife", "Opfindelsen af bordkniven");
            TimelineSentences.Add("The Invention of the Tank", "Opfindelsen af tanken");
            TimelineSentences.Add("The Invention of the Tea Bag", "Opfindelsen af teposen");
            TimelineSentences.Add("The Invention of the Tin Can", "Opfindelsen af blikdåsen");
            TimelineSentences.Add("The Invention of the Toaster", "Opfindelsen af brødristeren");
            TimelineSentences.Add("The Invention of the Traffic Light", "Opfindelsen af trafiklys");
            TimelineSentences.Add("The Invention of the Videogame Console", "Opfindelsen af videospilkonsollen");
            TimelineSentences.Add("The Invention of the Water Clock", "Opfindelsen af vanduret");
            TimelineSentences.Add("The Invention of the Zipper", "Opfindelsen af lynlåsen");
            TimelineSentences.Add("The Invention of Wine", "Opfindelsen af vin");
            TimelineSentences.Add("The Legend of Robin Hood", "Legenden om Robin Hood");
            TimelineSentences.Add("The Legend of the Minotaur", "Legenden om minotaurosen");
            TimelineSentences.Add("The Revolt of Spartacus", "Spartacus' oprør");
            TimelineSentences.Add("The Tale of Cinderella, or the Little Glass Slipper", "Fortællingen om Askepot og hendes glassko");
            TimelineSentences.Add("The Tale of Snow White", "Fortællingen om snehvide");
            TimelineSentences.Add("The Three Musketeers", "De tre musketerer");
            TimelineSentences.Add("The Venus de Milo", "Venus fra Milo (græsk skulptur)");
            TimelineSentences.Add("The Voyage to the Moon", "Filmen Rejsen til månen");
            TimelineSentences.Add("The West Side Story Musical", "West Side Story Musical");
        }

        public string TranslateToDanish(string englishWord)
        {
            if (TimelineSentences.ContainsKey(englishWord))
            {
                return TimelineSentences[englishWord];
            }
            else
            {
                return null;
            }
        }
    }
}
 