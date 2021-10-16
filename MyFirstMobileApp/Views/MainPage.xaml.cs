using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyFirstMobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void btnCompute_Clicked(System.Object sender, System.EventArgs e)
        {
            /// Exam = 50%
            /// Quiz = (SUM(Q1+....Qn)/n) * 40%
            /// Attendance = 10%
            ///

            var exam = string.IsNullOrEmpty(txtExamScore.Text) ? 0 : int.Parse(txtExamScore.Text);

            int quiz1 = 0;

            if (!string.IsNullOrEmpty(txtQuiz1.Text))
            {
                quiz1 = int.Parse(txtQuiz1.Text);
            }

            var quiz2 = int.Parse(txtQuiz2.Text);
            var attendance = int.Parse(txtAttendance.Text);

            var finalGrade = ComputeGrade(exam, quiz1, quiz2, attendance);

            lblGrade.Text = String.Format("{0:N2}", finalGrade);
        }

        public double ComputeGrade(int exam, int quiz1, int quiz2, int attendance)
        {
            return (exam * 0.5) + (((quiz1 + quiz2) / 2) * 0.4) + (attendance * 0.1);
        }


        void btnGoToAboutPage_Clickked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new AboutPage());
            });
        }

    }
}
