# Oefeningen Unit Tests

Schrijf bij deze oefeningen in commentaar steeds een bijhorende test case boven je tests. Dit hoeft niet lang te zijn. Denk hierbij aan precondities, testdata , uit te voeren stappen, verwachte resultaat.

## Calculator

Deze opgave maak je met de solution die je kan vinden in de map Calculator.
Je krijgt voor deze oefening al de nodige klasses. In de solution Calculator kan je 2 projecten terug vinden. In het eerste project vindt je de code die we wensen te testen. De Calculator klasse bevat een aantal methodes die we wensen te testen.
In het andere project vindt je reeds de CalculatorTests klasse. Hierin mag je alle testen schrijven. Voor jullie zijn in dit project reeds de xunit packages voorzien en een referentie naar het Calculator project.

Schrijf testen voor alle methodes in de calculator klasse.

Gebruik hiervoor de geziene technieken in de les.
Let zeker op volgende zaken:

- Naamgeving
- Test voldoende cases + zorg dat alle codepaden getest zijn.
- AAA-techniek


## Drankautomaat

In de folder FrisdrankAutomaat vindt je een project die een frisdrankautomaat simuleert.
In de applicatie wordt de automaat telkens random opgevuld. Nadien kan je 3 basis acties uitvoeren:

- Munten in werpen
- Een item aankopen
- Geld terug vragen

Voorzie een test project met alle nodige zaken.
Schrijf alle nodige/nuttige tests voor de publieke properties en methodes in de klasse VendingMachine.
Schrijf minstens volgende tests:

- Er kunnen dranken aan de automaat toegevoegd worden
  - De methode FillRandomly moet je niet testen. Deze maakt gebruik van random waarden, dit kunnen we nu nog niet testen.
- Munten inwerpen.
- Terug krijgen van geld wanneer dit gevraagd wordt.
- Aankopen van een drankje. Voorzie ook tests wanneer je in exception states komt.


