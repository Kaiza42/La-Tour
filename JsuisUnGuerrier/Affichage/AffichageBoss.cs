using JsuisUnGuerrier.Etage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsuisUnGuerrier.Affichage
{
    internal class AffichageBoss
    {
        public static void EntreEtageDragon()
        {
            Console.Clear();
            Affichage.Centre("******************************************************");
            Affichage.Centre($"*   Bienvenue Aventurier dans l'Etage {Etage1.compteurEtage} De la tour ! *");
            Affichage.Centre($"******************************************************");
            Console.WriteLine();
            Dragon();
            Console.ReadKey(true);
            Console.Clear();
        }
        public static void Dragon()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Affichage.Centre(@"                                    \/");
            Affichage.Centre(@"                                       ^`'.");
            Affichage.Centre(@"                                       ^   `'..");
            Affichage.Centre(@"             (                         ^      `'..");
            Affichage.Centre(@"           )  )        \/              ^         `'..");
            Affichage.Centre(@"         (   ) @       /^              ^            `'..");
            Affichage.Centre(@"       )  )) @@  )    /  ^             ^               `'..");
            Affichage.Centre(@"      ( ( ) )@@      /    ^            ^                  `'..");
            Affichage.Centre(@"    ))  ( @@ @ )    /      ^           ^                     `'..");
            Affichage.Centre(@"   ( ( @@@@@(@     /       |\_/|,      ^                        `'..");
            Affichage.Centre(@"  )  )@@@(@@@     /      _/~/~/~|C     ^                           `'..");
            Affichage.Centre(@"((@@@(@@@@@(     /     _(@)~(@)~/\C    ^                              `'..");
            Affichage.Centre(@"  ))@@@(@@)@@   /     /~/~/~/~/`\~`C   ^             __.__               `'..");
            Affichage.Centre(@"   )@@@@(@@)@@@(     (o~/~o)^,) \~ \C  ^          .' -_'-'""...             `..");
            Affichage.Centre(@"    ( (@@@)@@@(@@@@@@_~^~^~,-/\~ \~ \C/^        /`-~^,-~-`_~-^`;_           `..");
            Affichage.Centre(@"      @ )@@@(@@@@@@@   \^^^/  (`^\.~^ C^.,  /~^~^~^/_^-_`~-`~-~^\- /`'-./`'-. ;");
            Affichage.Centre(@"       (@ (@@@@(@@      `''  (( ~  .` .,~^~^-`-^~`/'^`-~ _`~-`_^-~\         ^^");
            Affichage.Centre(@"           @jgs@             (((` ~ .-~-\ ~`-_~`-/_-`~ `- ~-_- `~`..");
            Affichage.Centre(@"          /                 /~((((` . ~-~\` `  ~ |:`-_-~_~`  ~ _`-`;");
            Affichage.Centre(@"         /                 /~-((((((`.\-~-\ ~`-`~^\- ^_-~ ~` -_~-_`~`..");
            Affichage.Centre(@"        /                 /-~-/(((((((`\~-~\~`^-`~`\ -~`~\-^ -_~-_`~-`..");
            Affichage.Centre(@"       /                 /~-~/  `((((((|-~-|((`.-~.`Y`_,~`\ `,- ~-_`~-`;");
            Affichage.Centre(@"      /              ___/-~-/     `""""|~-~|''' / ~-^ .'    `:~`-_`~-~`;");
            Affichage.Centre(@"     / _____ /  / ~-~/           | -~-|      / -~-~.`      `:~^`-_`^-:");
            Affichage.Centre(@"    / _____ / (((((((((((((`                                `:~^-_~-`");
            Affichage.Centre(@"    \___ /                                                   `:_ ^ -~`;");
            Affichage.Centre(@"                                                              `:~-^`:");
            Affichage.Centre(@"                                                             ,`~-~`,` ");
            Affichage.Centre(@"                                                            ,''`~.,'");
            Affichage.Centre(@"                                                           ,'-`,'`");
            Affichage.Centre(@"                                                          ,'_`,'");
            Affichage.Centre(@"                                                         ,','`");
            Affichage.Centre(@"                                                        ; ~-~_~~;");
            Affichage.Centre(@"                                                        '. ~.'");
            Console.ResetColor();
        }
        public static void EntreEtageVampire()
        {
            Console.Clear();
            Affichage.Centre("******************************************************");
            Affichage.Centre($"*   Bienvenue Aventurier dans l'Etage {Etage1.compteurEtage} De la tour ! *");
            Affichage.Centre($"******************************************************");
            Console.WriteLine();
            Vampire();
            Console.ReadKey(true);
            Console.Clear();
        }
        public static void Vampire()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Affichage.Centre("                     __,-----,,,,  ,,,--------,__");
            Affichage.Centre("                _-/|\\/|\\/|\\\\|/\\/\\\\//|/|//|\\\\_");
            Affichage.Centre("               /|\\/\\//\\\\\\\\\\\\\\\\///////////\\\\\\");
            Affichage.Centre("             //|//           \\\\///            |\\\\|\\");
            Affichage.Centre("            ///|\\/             \\/               \\\\\\|\\");
            Affichage.Centre("           |/|//                                 |\\\\|\\");
            Affichage.Centre("          |/|/                                    \\\\\\|\\");
            Affichage.Centre("          ///;    ,,=====,,,  ~~-~~  ,,,=====,,    ;|\\\\|\\");
            Affichage.Centre("         |/|/   '\"          `'     '\"          '\"   ;|\\|");
            Affichage.Centre("         ||/`;   _--~~~~--__         __--~~~~--_   ;/|\\|");
            Affichage.Centre("         /|||;  :  /       \\~~-___-~~/       \\  :  ;|\\|");
            Affichage.Centre("         /\\|;    -_\\  (o)  / ,'; ;', \\  (o)  /_-    ;||");
            Affichage.Centre("         |\\|;      ~-____--~'  ; ;  '~--____-~      ;\\|");
            Affichage.Centre("          ||;            ,`   ;   ;   ',            ;||");
            Affichage.Centre("        __|\\ ;        ,'`    (  _  )    `',        ;/|__");
            Affichage.Centre("    _,-~###\\|/;    ,'`        ~~ ~~        `',    ;|\\###~-_,");
            Affichage.Centre("  ,'#########||;  '                           '  ;\\|/#######`,");
            Affichage.Centre(" .############; ,         _--~~-~~--_           ;#############'.");
            Affichage.Centre(",-' `;-,########;        ,; |_| | |_| ;,       ;;########,-;' `-,");
            Affichage.Centre("      ;@`,######;       ;_| :%`~'~'%: |_;       ;######,'@;");
            Affichage.Centre("       ;@@`,#####;     :%%`\\/%%%%%%%\\/`%%:     ;#####,'@@;");
            Affichage.Centre("        ;@@@`,####;     :%%%%%%%%%%%%%%%;     ;####,'@@@;");
            Affichage.Centre("         ;@@@@`,###;     ;./\\_%%%%%_/\\.;     ;####,@@@@;");
            Affichage.Centre("spb   _-'@@@@@@@@;-~;     ~~--|~|~|--~~     ;~--;@@@@@@@'-_");
            Affichage.Centre("  _,-'@@@@@@@@@@@@;  ;        ~~~~~        ;   ;@@@@@@@@@@@`-,_");
            Affichage.Centre(",~@@@@@@@@@@@@@@@@@;  \\`~--__         __--~/  ;@@@@@@@@@@@@@@@@~,");
            Affichage.Centre("@@@@@@@@@@@@@@@@@@@@;   \\   ~~-----~~    /   ;@@@@@@@@@@@@@@@@@@@");
            Affichage.Centre("@@@@@@@@@@@@@@@@@@@@@@~-_  \\  /  |  \\   /  _-~@@@@@@@@@@@@@@@@@@@@");
            Affichage.Centre("@@@@@@@@@@@@@@@@@@@@@@@@@~~-\\/   |   \\/ -~~@@@@@@@@@@@@@@@@@@@@@@@");
            Affichage.Centre("@@@@@@@@@@@@@@@@@@@@@@@@(=)=;==========;=(=)@@@@@@@@@@@@@@@@@@@@@@");
            Affichage.Centre("@@@@@@@@@@@@@@@@@@@@@@@@@@@@;    |     ;@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.ResetColor();
        }

    }
}
