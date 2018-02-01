using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FootballStatistics
{
    public partial class CalculatorStats : Form
    {
        public CalculatorStats()
        {
            InitializeComponent();
        }

       public double homeMiuScored;
       public double homeMiuConceded;
        public double awayMiuScored;
        public double awayMiuConceded;
        public double[] homeScoreArr =new double[7];
        public double[] homeConcedArr = new double[7];
        public double[] awayScoreArr = new double[7];
        public double[] awayConcedArr = new double[7];
        public double[][] foomatchArray = new double[4][];

        public void doCalcGscored()
        {
            int n1, n2, n3, n4, n5;
            Calculations calculations=new Calculations();
            try
            {
                n1 = int.Parse(scored1.Text);
                n2 = int.Parse(scored2.Text);
                n3 = int.Parse(scored3.Text);
                n4 = int.Parse(scored4.Text);
                n5 = int.Parse(scored5.Text);
                
            }
            catch (Exception)
            {
                warningLabel.Text = "Must input only numbers";
                return;
            }

            if (checkBox1.Checked)
            {
                homeMiuScored = calculations.meanMiuCalc(n1, n2, n3, n4, n5);
                homeScoreArr = calculations.standardeviat(n1, n2, n3, n4, n5);
            }
            else
            {
                awayMiuScored = calculations.meanMiuCalc(n1, n2, n3, n4, n5);
                awayScoreArr = calculations.standardeviat(n1, n2, n3, n4, n5);

            }

        }

        public void doCalcGconced()
        {
            int n1, n2, n3, n4, n5;
            Calculations calculations = new Calculations();
            try
            {
                n1 = int.Parse(conceded1.Text);
                n2 = int.Parse(conceded2.Text);
                n3 = int.Parse(conceded3.Text);
                n4 = int.Parse(conceded4.Text);
                n5 = int.Parse(conceded5.Text);

            }
            catch (Exception)
            {
                warningLabel.Text = "Must input only numbers";
                return;
            }

            if (checkBox1.Checked)
            {
                homeMiuConceded= calculations.meanMiuCalc(n1, n2, n3, n4, n5);
                homeConcedArr = calculations.standardeviat(n1, n2, n3, n4, n5);
            }
            else
            {
                awayMiuConceded = calculations.meanMiuCalc(n1, n2, n3, n4, n5);
                awayConcedArr = calculations.standardeviat(n1, n2, n3, n4, n5);

            }
        }
        private void btnMiuHscored_Click(object sender, EventArgs e)
        {
            doCalcGscored();
            miuHgoalScored.Text = homeMiuScored.ToString();
            homeGscoLabelarray.Text = ("Home Goals Scored results:" +
                " meanMiu: " + homeScoreArr[0]+
               ", miupower2: "+homeScoreArr[1]+
               ", sumxpower2px: "+homeScoreArr[2]+
               ", variance: "+homeScoreArr[3]+
               ", standardDeviation "+homeScoreArr[4]+
               "; Z number to look: "+homeScoreArr[5]);
            lblHSZ.Text = ("Home Scored Z= "+homeScoreArr[5]);
        }

        private void btnMiuHomeConced_Click(object sender, EventArgs e)
        {           
                doCalcGconced();
                miuHgoalConced.Text = homeMiuConceded.ToString();
                homeConcedLabelArr.Text = ("Home Goals Conceded results:" +
                    " meanMiu: " + homeConcedArr[0] +
                   ", miupower2: " + homeConcedArr[1] +
                   ", sumxpower2px: " + homeConcedArr[2] +
                   ", variance: " + homeConcedArr[3] +
                   ", standardDeviation " + homeConcedArr[4] +
                   "; Z number to look: " + homeConcedArr[5]);
            lblHCZ.Text = ("Home Conceded Z= "+homeConcedArr[5]);
        }

        private void btnMiuAwascored_Click(object sender, EventArgs e)
        {
            doCalcGscored();
            miuAwaygoalScoredlbl.Text = awayMiuScored.ToString();
            lblAwaScoArra.Text = ("Away Goals Scored results:" +
                " meanMiu: " + awayScoreArr[0] +
               ", miupower2: " + awayScoreArr[1] +
               ", sumxpower2px: " + awayScoreArr[2] +
               ", variance: " + awayScoreArr[3] +
               ", standardDeviation " + awayScoreArr[4] +
               "; Z number to look: " + awayScoreArr[5]);
            lblASZ.Text = ("Away Scored Z= "+awayScoreArr[5]);
        }

        private void btnMiuAwayConceded_Click(object sender, EventArgs e)
        {
            doCalcGconced();
            miuAwgoalconcedelabl.Text = awayMiuConceded.ToString();
            lblAwaConceArr.Text = ("Home Goals Conceded results:" +
                " meanMiu: " + awayConcedArr[0] +
               ", miupower2: " + awayConcedArr[1] +
               ", sumxpower2px: " + awayConcedArr[2] +
               ", variance: " + awayConcedArr[3] +
               ", standardDeviation " + awayConcedArr[4] +
               "; Z number to look: " + awayConcedArr[5]);
            lblACZ.Text = ("Away Conceded Z= "+awayConcedArr[5]);
        }

        private void btnCalcHomScorZ_Click(object sender, EventArgs e)
        {
            double zpercentage = double.Parse(txBoxZhomScor.Text);
            if (checkBxInvertHomeSco.Checked)
            {
                zpercentage = (10000 - zpercentage)/100;
                lblHomScorResult.Text = (" "+zpercentage);
                homeScoreArr[6] = zpercentage;
            }
            else
            {
                zpercentage = zpercentage / 100;
                lblHomScorResult.Text = (" " + zpercentage);
                homeScoreArr[6] = zpercentage;
            }
        }

        private void btnCalcHomConceZ_Click(object sender, EventArgs e)
        {
            double zpercentage = double.Parse(txBoxZhomConced.Text);
            if (checkBxInvertHomeConc.Checked)
            {
                zpercentage = (10000 - zpercentage) / 100;
                lblHomCorResult.Text = (" " + zpercentage );
                homeConcedArr[6] = zpercentage;
            }
            else
            {
                zpercentage = zpercentage / 100;
                lblHomCorResult.Text = (" " + zpercentage);
                homeConcedArr[6] = zpercentage;
            }

            homeGscoLabelarray.Text = (homeGscoLabelarray.Text + "; Scored %: "
                + homeScoreArr[6] + "; Conceded %: " + homeConcedArr[6]);
        }

        private void btnCalcAwaySorZ_Click(object sender, EventArgs e)
        {
            double zpercentage = double.Parse(txBoxZawayScor.Text);
            if (checkBxInvertAwaySco.Checked)
            {
                zpercentage = (10000 - zpercentage) / 100;
                lblAwayScorResult.Text = (" " + zpercentage);
                awayScoreArr[6] = zpercentage;
            }
            else
            {
                zpercentage = zpercentage / 100;
                lblAwayScorResult.Text = (" " + zpercentage);
                awayScoreArr[6] = zpercentage;
            }
        }

        private void btnCalcAwayConceZ_Click(object sender, EventArgs e)
        {
            double zpercentage = double.Parse(txBoxZawayconced.Text);
            if (checkBxInvertAwayConced.Checked)
            {
                zpercentage = (10000 - zpercentage) / 100;
                lblAwayConceResult.Text = (" " + zpercentage);
                awayConcedArr[6] = zpercentage;
            }
            else
            {
                zpercentage = zpercentage / 100;
                lblAwayConceResult.Text = (" " + zpercentage);
                awayConcedArr[6] = zpercentage;
            }

            lblAwaScoArra.Text = (lblAwaScoArra.Text + "; Scored %: "
                + awayScoreArr[6] + "; Conceded %: " + awayConcedArr[6]);
        }

        private void btnDoPercentage_Click(object sender, EventArgs e)
        {
            double combinedPercentage = (homeScoreArr[6] + homeConcedArr[6] +
                awayScoreArr[6] + awayConcedArr[6]) / 4;
            lblPercentage.Text = combinedPercentage.ToString();
        }
    }
}
