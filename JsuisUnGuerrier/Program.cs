using JsuisUnGuerrier.Classes;

Elfe jaquie = new Elfe("jaquie", 600,30);
Nain jean = new Nain("jean", 350, 30, true);

jaquie.AfficherInfos();
jean.AfficherInfos();

jean.SubirDegats(jaquie.Attaquer());
jean.AfficherInfos();


jaquie.SubirDegats(jean.Attaquer());
jaquie.AfficherInfos();

jean.SubirDegats(jaquie.Attaquer());
jean.AfficherInfos();



