using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Home : System.Web.UI.Page
    {

        public void Kosova()
        {
            string rez = "Kosova" + "\n\n";
            rez += "Koordinatat  Shkallë" + "\n\n" + "Gjerësia veriore 43° 16’" + "\n\n" + "Gjerësia jugore 41° 53’" + "\n\n" + "Gjatësia lindore 21° 16’" + "\n\n" + "Gjatësia perëndimore 19° 59’" + "\n\n" + "Kryeqyteti" + "\n\n" + "Prishtina 42°40 N 21°10 E / 42.667, 21.167" + "\n\n" + "Sipërfaqja: Total 10,908 km²" + "\n\n" + "Gjatësia e kufijve të Kosovës me shtetet fqinje" + "\n\n" + "Shqipëria 111.8, Maqedonia 158.7, Mali i Zi 78.6, Serbia 351.6";
            string str = rez.Replace("\n\n", "<br></br>");
            Label1.Text = str;
        }
        public void Kushtetuta()
        {
            string rez = "Kushtetuta" + "\n\n";
           rez += "Kushtetuta është akti më i lartë juridik i Republikës së Kosovës. Ligjet dhe aktet e tjera juridike duhet të jenë në pajtim me këtë Kushtetutë. Kushtetuta është një sistem për qeverisje, shpesh e koduar në formën e një dokumenti, e cila vë bazat e rregullave dhe principeve themelore të një republike autonome. Kushtetuta përcakton principet themelore politike, strukturën, procedurat, fuqinë dhe përgjegjësitë e qeverisë. Pushteti qeverisës në Republikën e Kosovës buron nga Kushtetuta. Mënyra e punës dhe procedurat e vendimmarrjes në Qeveri rregullohen me ligj dhe me rregullore. Republika e Kosovës respekton të drejtën ndërkombëtare. Secili person dhe organ në Republikën e Kosovës u nënshtrohet dispozitave të Kushtetutës. Gjykata Kushtetuese është organ i pavarur i mbrojtjes së kushtetutshmërisë dhe bën interpretimin përfundimtar të Kushtetutës.Sovraniteti i Republikës së Kosovës buron nga populli, i takon popullit dhe ushtrohet, në pajtim me Kushtetutën, nëpërmjet përfaqësuesve të zgjedhur, me referendum, si dhe në forma të tjera, në pajtim me dispozitat e kësaj Kushtetute. Rendi kushtetues i Republikës së Kosovës bazohet në parimet e lirisë, paqes, demokracisë, barazisë, respektimit të të drejtave dhe lirive të njeriut dhe sundimit të ligjit, mosdiskriminimit, të drejtës së pronës, mbrojtjes e mjedisit, drejtësisë sociale, pluralizmit, ndarjes së pushtetit shtetëror dhe ekonomisë së tregut. Historia e Kushtetutës së Republikës së Kosovë. Drafti i Kushtetutës së re të Republikës së Kosovës u përgatit dhe u publikua në Prill të vitit 2008. Shumë nga nenet e draftit të Kushtetutës së re u bazuan dhe rrjedhuan nga plani i Ahtisaarit, kështu që kushtetuta u garantonte të drejta të veçanta grupeve të minoriteteve dhe siguronte një mjedis më të sigurte për të gjithë qytetarët e Republikës së Kosovës." + "\n\n";
             rez += "17 Shkurt, 2008 - Kosova u shpall shtet sovran, i pavarur më 17 Shkurt të 2008, në mbledhjen e jashtëzakonshme të Kuvendit të Kosovës. Deklarata e Pavarësisë ishte një Akt i Kuvendit të Kosovës si Institucion i Përkohshëm i Vetë-Qeverisjes, i pranuar unanimisht nga të gjithë anëtarët prezentë të kuvendit, 109 anëtarë. Deklarata e Pavarësisë u lexua nga Kryeministri i Kosovës, z. Hashim Thaqi" + "\n\n";
             rez += "2 Prill, 2008 - Komisioni Kushtetues miraton tekstin e Projekt–Kushtetutës së Republikës së Kosovës. Po në këtë ditë Projekt – Kushtetuta e Republikës së Kosovës Certifikohet." + "\n\n";

            rez += "8 Prill, 2008 - Kushtetuta e Republikës së Kosovës nënshkruhet nga Presidenti I Republikës së Kosovës në Bibliotekën Kombëtare të Kosovës, Prishtinë, Kosovë." + "\n\n";

             rez += "9 Prill, 2008 - Draft- Kushtetuta e Republikës së Kosovës u ratifikua në Kuvendin e Republikës së Kosovës." + "\n\n";
            rez += "15 Prill, 2008 - Kushtetuta e Republikës së Kosovës u fuqizua plotësisht si akti më i lartë juridik i Republikës së Kosovës." + "\n\n";
            string str = rez.Replace("\n\n", "<br></br>");
            Label1.Text = str;
        }
        public void Qeveria()
        {
             string rez = "Qeveria" + "\n\n";
             rez += "Qeveria e Kosovës ushtron pushtetin ekzekutiv në pajtim me Kushtetutën dhe me ligjin. Qeverinë e Kosovës e përbëjnë Kryeministri, zëvendëskryeministrat dhe ministrat. Qeveria zbaton ligjet dhe aktet e tjera të miratuara nga Kuvendi i Kosovës dhe ushtron veprimtari tjera brenda përgjegjësive të përcaktuara me këtë Kushtetutë dhe me ligj. Qeveria merr vendime në pajtim me këtë Kushtetutë dhe me ligje, propozon projektligje dhe amendamentimin e ligjeve ekzistuese e akteve të tjera, si dhe mund të japë mendimin rreth projektligjeve të cilat nuk janë të propozuara nga ajo. Qeveria, për punën e vet, i përgjigjet Kuvendit të Kosovës. Kryeministri, zëvendëskryeministrat dhe ministrat mbajnë bashkëpërgjegjësinë për vendimet që merr Qeveria, dhe përgjegjësinë individuale për vendimet që marrin në fushat e përgjegjësive të tyre.Qeveria ka këto kompetenca:" + "\n\n" +
                "propozon dhe zbaton politikën e brendshme dhe të jashtme të vendit;" + "\n\n" +
                "mundëson zhvillimin ekonomik të vendit;" + "\n\n" +
                "propozon Kuvendit projektligje dhe akte të tjera;" + "\n\n" +
                "merr vendime dhe nxjerr akte juridike ose rregullore, të nevojshme për zbatimin e ligjeve;" + "\n\n" +
                "propozon Buxhetin e Republikës së Kosovës;" + "\n\n" +
                "udhëzon dhe mbikëqyr punën e organeve të administratës;" + "\n\n" +
                "udhëzon veprimtarinë dhe zhvillimin e shërbimeve publike;";

             string str = rez.Replace("\n\n", "<br></br>");
             Label1.Text = str;
        }
        public void Financa()
        {
            string rez = "Financat" + "\n\n";
            rez += "Tre funksionet kryesore të parasë janë:" + "\n\n" +
                "Funksioni parasë si mjet këmbimi dhe pagese" + "\n\n" +
                "Funksioni i ruajtjes se vlerës" + "\n\n" +
            "Funksionin e vlerës së mallrave dhe shërbimeve" + "\n\n";
             rez+= "Banka Qendrore e Republikës së Kosovës (BQK)" + "\n\n" +
                "Autoriteti Qendror Bankar i Kosovës (AQBK), pasardhës i Autoritetit Bankar dhe të Pagesave të Kosovës (BPK) është një entitet publik i veçantë i cili ka të drejtë të licencojë, mbikëqyrë dhe rregullojë institucionet financiare në territorin e Kosovës. ";
             string str = rez.Replace("\n\n", "<br/>");
            Label1.Text = str;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Kosova(object sender, EventArgs e)
        {
            Kosova();
        }

        protected void btnKush_Click(object sender, EventArgs e)
        {
            
            Kushtetuta();
        }

        protected void btnQeve_Click(object sender, EventArgs e)
        {
            Qeveria();
        }

        protected void btnFinanca_Click(object sender, EventArgs e)
        {
            Financa();
        }
    }
}