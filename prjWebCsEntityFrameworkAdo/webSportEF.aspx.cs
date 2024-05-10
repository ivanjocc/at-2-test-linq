using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjWebCsEntityFrameworkAdo
{
    public partial class webSportEF : System.Web.UI.Page
    {
        //variables globales
        static DBSportEntities1 myEFSport;
        static string mode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack == false)
            {
                myEFSport = new DBSportEntities1();
                RemplirListeEquipes();
            }
        }

        private void RemplirListeEquipes()
        {
            ////version boucle avec EF
            //foreach(Equipe eq in myEFSport.Equipes)
            //{
            //    ListItem elm = new ListItem();
            //    elm.Text = eq.Nom;
            //    elm.Value = eq.RefEquipe.ToString();
            //    lstEquipes.Items.Add(elm);
            //}


            ////version databinding avec EF
            //lstEquipes.DataTextField = "Nom";
            //lstEquipes.DataValueField = "RefEquipe";
            //lstEquipes.DataSource = myEFSport.Equipes.ToList();
            //lstEquipes.DataBind();



            //version linq avec EF
            var lesEquipes = from Equipe eq in myEFSport.Equipes
                             select new
                             {
                                 Nom = eq.Nom,
                                 RefEquipe = eq.RefEquipe,
                             };
            lstEquipes.DataTextField = "Nom";
            lstEquipes.DataValueField = "RefEquipe";
            lstEquipes.DataSource = lesEquipes.ToList();
            lstEquipes.DataBind();
        }

        protected void lstEquipes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //recuperer ref equipe de l'equipe choisi
            string refEqpChoisi = lstEquipes.SelectedItem.Value;
            //version Boucle avec EF
            //foreach (Equipe eq in myEFSport.Equipes)
            //{
            //    if (eq.RefEquipe.ToString() == refEqpChoisi)
            //    {
            //        txtNom.Text = eq.Nom;
            //        txtVille.Text = eq.Ville;
            //        txtCoach.Text = eq.Coach;
            //        txtBudget.Text = eq.Budget.ToString();

            //        //afficher les joueurs de cette equipe dans le grid 
            //        gridJoueurs.DataSource = eq.Joueurs.ToList();
            //        gridJoueurs.DataBind();

            //        break;
            //    }
            //}


            //version EF avec la methode find()
            Equipe eq = myEFSport.Equipes.Find(Convert.ToInt32(refEqpChoisi));
            txtNom.Text = eq.Nom;
            txtVille.Text = eq.Ville;
            txtCoach.Text = eq.Coach;
            txtBudget.Text = eq.Budget.ToString();
            //afficher les joueurs de cette equipe dans le grid 
            gridJoueurs.DataSource = eq.Joueurs.ToList();
            gridJoueurs.DataBind();

        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            mode = "ajout";
            txtBudget.Text = txtCoach.Text = txtVille.Text = txtNom.Text = "";
            txtNom.Focus();
        }

        protected void btnModifier_Click(object sender, EventArgs e)
        {
            mode = "modif";

            txtNom.Focus();
        }

        protected void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (lstEquipes.SelectedItem == null)
            {
                return;
            }

            int refEqpChoisi = Convert.ToInt32(lstEquipes.SelectedItem.Value);

            Equipe equipeASupprimer = myEFSport.Equipes.Find(refEqpChoisi);

            if (equipeASupprimer != null)
            {
                myEFSport.Equipes.Remove(equipeASupprimer);

                myEFSport.SaveChanges();

                RemplirListeEquipes();

                ClearFields();
            }
            else
            {
                // message ici
            }
        }

        private void ClearFields()
        {
            txtNom.Text = "";
            txtVille.Text = "";
            txtCoach.Text = "";
            txtBudget.Text = "";
            gridJoueurs.DataSource = null;
            gridJoueurs.DataBind();
        }


        protected void btnSauvgarder_Click(object sender, EventArgs e)
        {
            if(mode == "ajout")
            {
                //creer lequipe
                Equipe nouvelle = new Equipe();
                //recuperer les champs
                nouvelle.Nom = txtNom.Text;
                nouvelle.Ville = txtVille.Text;
                nouvelle.Budget = Convert.ToDecimal(txtBudget.Text);
                nouvelle.Coach = txtCoach.Text;
                //ajouter lequipe a equipes 
                myEFSport.Equipes.Add(nouvelle);
                //ajouter a la bdd
                myEFSport.SaveChanges();
                RemplirListeEquipes();
            }
            else if (mode == "modif")
            {
                int refEqpChoisi = Convert.ToInt32(lstEquipes.SelectedItem.Value);

                Equipe equipeAModifier = myEFSport.Equipes.Find(refEqpChoisi);

                if (equipeAModifier != null)
                {
                    equipeAModifier.Nom = txtNom.Text;
                    equipeAModifier.Ville = txtVille.Text;
                    equipeAModifier.Budget = Convert.ToDecimal(txtBudget.Text);
                    equipeAModifier.Coach = txtCoach.Text;
                }
                else
                {
                    return;
                }
            }

            myEFSport.SaveChanges();

            RemplirListeEquipes();

            ClearFields();

            mode = string.Empty;
        }

        protected void btnAnnuler_Click(object sender, EventArgs e)
        {
            txtNom.Text = "";
            txtVille.Text = "";
            txtCoach.Text = "";
            txtBudget.Text = "";

            lstEquipes.SelectedIndex = -1;

            gridJoueurs.DataSource = null;
            gridJoueurs.DataBind();
        }
    }
}