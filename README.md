# C#-minneshantering – Stack och Heap

## Översikt
Detta projekt syftar till att ge en djupdykning i C#-språkets minneshantering, med särskilt fokus på stack och heap. Projektet har skapats som en del av utbildningsuppgiften inom .NET-utveckling

## Problemställning

####  1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion

 ***Stack***  är ett minnesområde som används för att lagra värdetyper och metodanrop (funktioner och deras lokala variabler).
Minnet i stacken hanteras enligt Last In, First Out (LIFO)-principen. Detta innebär att den senaste variabeln som läggs på stacken är den första som tas bort.
Stacken används för värdetyper (int, char, bool, float etc.) och lokala variabler inom metoder.
När en metod anropas allokeras utrymme för dess lokala variabler på stacken. När metoden är klar frigörs automatiskt det minnet.

***Heap*** är ett minnesområde som används för att lagra referenstyper (t.ex. objekt, strängar, arrayer) som har längre livslängd än ett enskilt metodanrop.
Minnet i heapen hanteras mer dynamiskt och är inte lika strukturerat som stacken. Minnet måste både allokeras och frigöras manuellt eller via Garbage Collection (GC) som automatiskt tar bort objekt när de inte längre refereras.
Heapen används för referenstyper (t.ex. objekt som skapas med new).

```
int age = 30; // Lagras på stacken
string name = "Bob"; // Lagras på heapen
```

*I detta exempel lagras age på stacken eftersom det är ett heltal (värdetyp). name lagras på heapen eftersom det är en sträng (referenstyp).*

|  | Stacken | Heapen |
|---|---|---|
| **Datatyp** | Värdetyper och referenser | Endast referenstyper |
| **Minnesallokering** | Statisk, fast storlek | Dynamisk, växer vid behov |
| **Livslängd** | Kort, kopplad till metodanrop | Lång, hanteras av garbage collector |
| **Hastighet** | Snabb åtkomst | Långsammare åtkomst |
| **Användningsområde** | Lokala variabler, metodparametrar | Objekt, stora datastrukturer |

#### 2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?

En ***värdetyp*** är en datatyp som innehåller faktiska värden, exempelvis heltal, flyttal, booleska värden (sant eller falskt) och tecken. Dessa lagras direkt i minnet på den plats där variabeln är deklarerad, och de tar oftast mindre utrymme jämfört med referenstyper. Du kan även skapa egna värdetyper med hjälp av nyckelordet struct.

Exempel är:
![Screenshot 2024-09-23 at 15 43 24](https://github.com/user-attachments/assets/e9fa2f7d-d1ad-4ba5-9d98-1eb1eaef5f85)

En ***referenstyp*** är en datatyp som alltid lagras på heapen. Till skillnad från värdetyper, som lagrar själva värdet i minnet där variabeln deklareras, lagrar referenstyper en referens till minnesadressen där värdet finns lagrat.

Exempel:

- class
- interface
- object
- delegate
- string

#### 3. Följande metoder (se bild nedan) genererar olika svar. Den första returnerar 3, den andra returnerar 4, varför?
![Screenshot 2024-09-23 at 15 50 02](https://github.com/user-attachments/assets/eb8b0665-471e-4b8e-be09-2035844a9786)

Den första metoden returnerar 3 eftersom när raden `y = x` körs, kopieras värdet 3 från `x` till `y`, då de är värdetyper. Eftersom varje variabel har sin egen kopia av värdet, påverkas inte `x` när `y` tilldelas ett nytt värde på nästa rad. `x` behåller sitt ursprungliga värde, vilket är 3.

Den andra metoden returnerar 4 eftersom när raden `y = x` körs, refererar både `x` och `y` till samma objekt i minnet. När sedan `y.MyValue = 4` körs, ändras värdet på det gemensamma objektet, vilket innebär att både `y.MyValue` och `x.MyValue` nu har värdet 4.
