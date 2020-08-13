# SOLID Kata

## Was ist SOLID

### Single-Responsibility-Prinzip

Das Single-Responsibility-Prinzip besagt, dass jede Klasse nur eine einzige Verantwortung haben solle. Verantwortung wird hierbei als *Grund zur Änderung* definiert:

> Es sollte nie mehr als einen Grund dafür geben, eine Klasse zu ändern.

Mehr als eine Verantwortung für eine Klasse führt zu mehreren Bereichen, in denen zukünftige Änderungen notwendig werden können. Die Wahrscheinlichkeit, dass die Klasse zu einem späteren Zeitpunkt geändert werden muss, steigt zusammen mit dem Risiko, sich bei solchen Änderungen subtile Fehler einzuhandeln. Dieses Prinzip führt in der Regel zu Klassen mit hoher Kohäsion, in denen alle Methoden einen starken gemeinsamen Bezug haben.

### Open-Closed-Prinzip

Das Open-Closed-Prinzip besagt, dass Software-Einheiten (z.B. Module, Klassen, Methoden etc.) Erweiterungen möglich machen sollen (dafür offen sein), aber ohne dabei ihr Verhalten zu ändern.

> Module sollten sowohl offen (für Erweiterungen), als auch geschlossen (für Modifikationen) sein.

Eine Erweiterung im Sinne des Open-Closed-Prinzips ist beispielsweise die Vererbung. Diese verändert das vorhandene Verhalten einer Klasse nicht, erweitert sie aber um zusätzliche Funktionen oder Daten. Überschriebene Methoden verändern auch nicht das Verhalten der Basisklasse, sondern nur das der abgeleiteten Klasse. 

### Liskovsches Substitutionsprinzip

Das Liskovsche Substitutionsprinzip (LSP) oder Ersetzbarkeitsprinzip fordert, dass eine Instanz einer abgeleiteten Klasse sich so verhalten muss, dass jemand, der meint, ein Objekt der Basisklasse vor sich zu haben, nicht durch unerwartetes Verhalten überrascht wird, wenn es sich dabei tatsächlich um ein Objekt eines Subtyps handelt. 

Damit ist garantiert, dass Operationen vom Typ Superklasse, die auf ein Objekt des Typs Subklasse angewendet werden, auch korrekt ausgeführt werden. Dann lässt sich stets bedenkenlos ein Objekt vom Typ Superklasse durch ein Objekt vom Typ Subklasse ersetzen. Objektorientierte Programmiersprachen können eine Verletzung dieses Prinzips, die aufgrund der mit der Vererbung verbundenen Polymorphie auftreten kann, nicht von vornherein ausschließen. Häufig ist eine Verletzung des Prinzips nicht auf den ersten Blick offensichtlich.

### Interface-Segregation-Prinzip

Das Interface-Segregation-Prinzip dient dazu, zu große Interfaces aufzuteilen. Die Aufteilung soll gemäß den Anforderungen der Clients an die Interfaces gemacht werden – und zwar derart, dass die neuen Interfaces genau auf die Anforderungen der einzelnen Clients passen. Die Clients müssen also nur mit Interfaces agieren, die das, und nur das können, was die Clients benötigen. Das Prinzip wurde von Robert C. Martin 1996 folgendermaßen formuliert:

> Clients sollten nicht dazu gezwungen werden, von Interfaces abzuhängen, die sie nicht verwenden.

Mit Hilfe des Interface-Segregation-Prinzips ist es möglich eine Software derart in entkoppelte und somit leichter refaktorisierbare Klassen aufzuteilen, dass zukünftige fachliche oder technische Anforderungen an die Software nur geringe Änderungen an der Software selbst benötigen.


### Dependency-Inversion-Prinzip

Das Dependency-Inversion-Prinzip beschäftigt sich mit der Reduktion der Kopplung von Modulen. Es besagt, dass Abhängigkeiten immer von konkreteren Modulen niedriger Ebenen zu abstrakten Modulen höherer Ebenen gerichtet sein sollten.

> Module hoher Ebenen sollten nicht von Modulen niedriger Ebenen abhängen. Beide sollten von Abstraktionen abhängen.

> Abstraktionen sollten nicht von Details abhängen. Details sollten von Abstraktionen abhängen.“

Damit ist sichergestellt, dass die Abhängigkeitsbeziehungen immer in eine Richtung verlaufen, von den konkreten zu den abstrakten Modulen, von den abgeleiteten Klassen zu den Basisklassen. Damit werden die Abhängigkeiten zwischen den Modulen reduziert und insbesondere zyklische Abhängigkeiten vermieden. 
