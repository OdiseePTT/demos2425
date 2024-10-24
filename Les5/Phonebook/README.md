
[![.NET](../../actions/workflows/main.yml/badge.svg)](../../actions/workflows/main.yml)

# Oefeningen Testdoubles

## PhoneBook

Schrijf unit tests voor de klasse [PhoneBookOperations.cs](/PhoneBook/PhoneBook/PhoneBookOperations.cs).

### Classes
Het project bestaat uit verschillende klasses. Hieronder bespreken we de belangrijkste klasses.

#### [Contact.cs](/PhoneBook/PhoneBook/Contact.cs)
De Contact klasse is een klassieke dataklasse zonder logica. Voor elke Contact worden onderstaande properties bijgehouden:

* Voornaam
* Familienaam
* Telefoonnummer
* IsFavoriet
* Sneltoets
* Id

#### [PhoneBook.cs](/PhoneBook/PhoneBook/PhoneBook.cs)
De PhoneBook klasse bevat de code om data weg te schrijven naar een JSON bestand. Met behulp van deze klasse kan je contacten opvragen, toevoegen, verwijderen en wijzigen. Deze klasse zorgt ervoor dat alle updates telkens worden opgeslagen in het JSON bestand

#### [PhoneBookOperations.cs](/PhoneBook/PhoneBook/PhoneBookOperations.cs)
De PhoneBookOperations klasse bevat alle logica/business rules die van toepassing zijn op het PhoneBook.

De klasse bevat 3 properties:
| Property   | Uitleg                                                                                                                   |
| ---------- | ------------------------------------------------------------------------------------------------------------------------ |
| Contacts   | Geeft alle contacten uit het telefoonboek terug                                                                          |
| Favorites  | Geeft een lijst van alle contacten die als favoriet zijn aangeduid                                                       |
| QuickDials | Geeft een array van 10 items terug. Wanneer een contact een quickdial nummer heeft, wordt dit op deze positie geplaatst. |

De klasse bevat 7 methodes:
| Methode              | Uitleg                                                                                                                                                                                              |
| -------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| AddContact(...)      | Voegt een nieuw contact toe. Deze methode gooit een error op wanneer het telefoonnummer ongeldig is of reeds bestaat of wanneer de voornaam of familienaam korter is dan 3 karakters.               |
| UpdateContact(...)   | Update een bestaand contact. Deze methode gooit een error op wanneer het telefoonnummer ongeldig is of reeds bestaat of wanneer de voornaam of familienaam korter is dan 3 karakters.               |
| Favorite(...)        | Stelt een contact in als favoriet.                                                                                                                                                                  |
| UnFavorite(...)      | Verwijdert een favoriet contact.                                                                                                                                                                    |
| AddQuickDial(...)    | Voegt een sneltoets toe voor een contact. Deze methode gooit een error wanneer een sneltoets al in gebruik is of wanneer een nummer gekozen wordt dat meer is dan het toegelaten aantal sneltoetsen |
| RemoveQuickDial(...) | Verwijdert een sneltoets voor een contact                                                                                                                                                           |
| RemoveContact(...)   | Verwijdert een contact                                                                                                                                                                              |


### Opdracht
Schrijf de nodige unit test voor de PhoneBookOperations. Maak hierbij gebruik van __zelf geschreven Test Doubles__!
1. Contacts => Geeft alle contacten terug. 🟢
2. Favorites => Geeft een lijst van favorieten terug. 🟢
3. QuickDials => Geeft een array van 10 items terug. Contacten met een sneltoets, staan op de juiste positie. 🟠
4. AddContacts
   1. Bij correcte data => Contact wordt zoals verwacht toegevoegd. Valideer ook het contact object. 🟢
   2. Bij ongeldig telefoonnummer => Error wordt opgegooid. 🟠
   3. Bij reeds bestaand telefoonnummer => Error wordt opgegooid. 🟠
   4. Bij te korte voornaam => Error wordt opgegooid. 🟠
   5. Bij te korte familienaam => Error wordt opgegooid. 🟠
5. UpdateContact
   1. Bij correcte data => Contact wordt toegevoegd. 🟠
   2. Bij ongeldig telefoonnummer => Error wordt opgegooid. 🟠
   3. Bij reeds bestaand telefoonnummer => Error wordt opgegooid. 🟠
   4. Bij te korte voornaam => Error wordt opgegooid. 🟠
   5. Bij te korte familienaam => Error wordt opgegooid. 🟠
6. Favorite => Contact wordt toegevoegd als favoriet. 🟠
7. UnFavorite => Contact wordt toegevoegd als favoriet. 🟠
8. AddQuickDial
   1. Met beschikbare sneltoets => Contact wordt correct geüpdatet. 🟠
   2. Met onbeschikbare sneltoets => Error wordt opgegooid. 🟢
   3. Met te hoge sneltoets => Error wordt opgegooid. 🟠
9. RemoveQuickDial => Sneltoets wordt verwijderd. 🟠
10. RemoveContact => Contact wordt verwijderd. 🟢

Items met 🟢 maak je zeker.
Items met 🟠 zijn optioneel.

### Stappenplan
1. Zorg er eerst en vooral voor dat je je PhoneBookOperations klasse kan testen zonder de PhoneBook klasse. Maak hiervoor een interface aan met de nodige methodes.
2. Zorg ervoor dat je dynamische een PhoneBook klasse kan instellen in de PhoneBookOperations klasse op basis van je net aangemaakte interface.
3. Schrijf je testen
   1. Evalueer steeds of je een testdouble nodig hebt.
   2. Welke testdouble heb je nodig?
   3. Kan je een reeds gemaakt hergebruiken?
   4. Vervolledig de test code.
