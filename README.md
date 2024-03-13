Att tänka på.

Se till att du är på rätt gren innan du börjar implementera ändringar. 


git pull // Hämtar ändringar och mergar dem med din branch.
git branch -a //För att se vilken branch du ligger i och alla lokala samt remote branches. 
git branch -r //För att bara se alla remote branches. 
git branch // Annat sätt för att se branches samt vilken branch du sitter på.
git checkout -b Feature/*Namnetpåfeature* //Skapa en ny branch.
git checkout *Namnet på branchen* //Hoppa eller flytta till den branchen.
git status // För att se hur du ligger till i din versionshantering i den branchen.


Steg för push i powershell
1. dotnet format // Formaterar koden.
2. git add .  (glöm inte punkten)
3. git commit -m "Förklaring på vad du har gjort" // Citat tecken måste finnas med. 
5. git push eller git push --set-upstream origin Feature/NamnetPåDinFeature //Bara om det är din första push på den branchen.
   
