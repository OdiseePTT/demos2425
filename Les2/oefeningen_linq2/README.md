[![.NET](../../actions/workflows/dotnet.yml/badge.svg)](../../actions/workflows/dotnet.yml)

# Oefeningen LINQ

## Numbers


In de map Numbers kan je een solution numbers vinden met een project Numbers. In dit project is reeds 1 klasse voorzien NumbersOperations. Deze klasse krijgt in de constructor een array van nummers mee. Hierop willen we enkele operaties kunnen uitvoeren.
Schrijf in deze klasse voor onderstaande vragen een LINQ-query in de bijhorende methodes.

Schrijf LINQ-query’s om de volgende gegevens te bekomen:

1. De getalen die groter of gelijk zijn aan 50
2. De getallen tussen 30 en 60 (beide grenzen inbegrepen)
3. Alle oneven getallen
4. De getallen die zowel een veelvoud zijn van 3 als van 5
5. Een IEnumerable<> waarbij elk getal vervangen werd door het dubbele van het oorspronkelijke getal
6. Een IEnumerable<> waarbij elk oneven getal vervangen werd door de helft van het oorspronkelijke getal
7. Het aantal getallen die een veelvoud zijn van 5 (tip: maak hiervoor uitsluitend gebruik van de Count(..)-methode!)
8. Het laatste getal in de array waarvan het kwadraat kleiner is dan 2000 (Tip: maak hiervoor uitsluitend gebruik van de methode Last(..)!
9. De som van alle getallen die deelbaar zijn door 5 of 6.
10. Alle oneven getallen in de array, gesorteerd van groot naar klein

### Testen

Schrijf voor elke query minstens 1 test (in een apart test-project) om jezelf te controleren.

## Cars

In de map Car vindt je de solution car. Hierin kan je een project car vinden met reeds 2 klasses: Car en CarOperations

Vervolledig de klasse CarOperations met volgende LINQ queries. Vul deze aan in de desbetreffende methodes.

1. Een List<> met alle auto’s die minder kosten dan €10.000,00 (tip: gebruik de ToList()-methode van IEnumerable<> om een IEnumerable om te zetten naar een List<>).
2. Alle auto’s die minder kosten dan €15.000,00 en die ná 2016 gebouwd zijn.
3. Een IEnumerable<> met alle model-namen van de verschillende auto’s (tip: gebruik de methode Distinct() om duplicaten te verwijderen).
4. Een List<> met de model-namen van alle auto’s met een automatische transmissie. Verwijder eventuele duplicaten!
5. Bereken de gemiddelde prijs van de auto’s met een manuele transmissie.
6. De prijs van de duurste auto van het merk Ford.
7. De drie goedkoopste auto’s met een bouwjaar ná 2016 (tip: maak gebruik van de methode Take(..) om het aantal resultaten te beperken).
8. Het aantal auto’s met een manuele transmissie die minder kosten dan €12.500,00.
9. Een List<> met de auto’s die een automatische transmissie hebben, gesorteerd van duur naar goedkoop.
10. Een lijst met de merknamen van de auto’s die meer kosten dan €12.000,00, alfabetische gesorteerd (aflopend). Vermijd dubbels!

### Testen

Maak net zoals in de opgave van Numbers een testproject waarbij je al je gemaakte methodes te test. Schrijf voor elke opgave minstens 1 test.

Indien je inspiratie nodig hebt voor een lijst van auto's kan je onderstaande gebruiken.

| Merk | Model  | Bouwjaar | Prijs      | Transmissie |
| ---- | ------ | -------- | ---------- | ----------- |
| VW   | Golf   | 2017     | €17.495,00 | MANUEEL     |
| VW   | Polo   | 2015     | €9.850,00  | AUTOMAAT    |
| Opel | Astra  | 2016     | €11.450,00 | AUTOMAAT    |
| VW   | Golf   | 2018     | €18.320,00 | AUTOMAAT    |
| Ford | Focus  | 2016     | €8.715,00  | MANUEEL     |
| Opel | Corsa  | 2017     | €9.120,00  | MANUEEL     |
| Ford | Fiësta | 2016     | €7890,00   | AUTOMAAT    |
