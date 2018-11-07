using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using PredictYourGradeApp.Models;
using PredictYourGradeApp.Services;
using Xamarin.Forms;

namespace PredictYourGradeApp.ViewModels
{
    public class PredictionGradeViewModel : BaseViewModel
    {
        private Student student;

        public PredictionGradeViewModel(Student s)
        {
            student = s;
            PredictCommand = new Command(async () =>
            {
                var grade = await PredictionService.PredictGrade(student);
                G3 = grade;
            });
        }

        private string sex;

        public string Sex
        {
            get { return student.Sex; }
            set
            {
                student.Sex = value;
                OnPropertyChanged();
            }
        }

        private int travelTime;

        public int TravelTime
        {
            get { return student.TravelTime; }
            set
            {
                student.TravelTime = value;
                OnPropertyChanged();
            }
        }

        private int studyTime;

        public int StudyTime
        {
            get { return student.StudyTime; }
            set
            {
                student.StudyTime = value;
                OnPropertyChanged();
            }
        }

        private string internet;

        public string Internet
        {
            get { return student.Internet; }
            set
            {
                student.Internet = value;
                OnPropertyChanged();
            }
        }

        private int g1;

        public int G1
        {
            get { return student.G1; }
            set
            {
                student.G1 = value;
                OnPropertyChanged();
            }
        }

        private int g2;

        public int G2
        {
            get { return student.G2; }
            set
            {
                student.G2 = value;
                OnPropertyChanged();
            }
        }

        private double g3;

        public double G3
        {
            get { return student.G3; }
            set
            {
                student.G3 = value;
                OnPropertyChanged();
            }
        }

        public Command PredictCommand { get; set; }

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }
    }
}
