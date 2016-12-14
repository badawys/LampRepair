using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpertSystemLamp
{
    public partial class Form1 : Form
    {

        ExpertSystem myExpertSystem;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Declare and initialize Questions and Rules lists
            List<Question> questions = new List<Question>();
            List<QuestionRule> rules = new List<QuestionRule>();

            // Add Quetions to the qutions list
            questions.Add(new Question(1, "Does the lamp works?"));
            questions.Add(new Question(2, "Power is On?"));
            questions.Add(new Question(3, "Is bulb bad?"));
            questions.Add(new Question(4, "Is Switch bad?"));
            questions.Add(new Question(5, "Is Plug bad?"));
            questions.Add(new Question(6, "Is Cord bad?"));
            questions.Add(new Question(7, "Fuse is Good?"));
            questions.Add(new Question(8, "Circuit Breaker on?"));
            questions.Add(new Question(9, "Is there a Power Failure?"));
            questions.Add(new Question(10, "Is Wall outlet bad?"));

            // Adding Rules to the rules list
            rules.Add(new QuestionRule(1, false, 2));
            rules.Add(new QuestionRule(1, true, "Nothing to fix"));       
            rules.Add(new QuestionRule(2, false, 7));
            rules.Add(new QuestionRule(2, true, 3));
            rules.Add(new QuestionRule(3, false, 4));
            rules.Add(new QuestionRule(3, true, "Replace the bulb"));
            rules.Add(new QuestionRule(4, false, 5));
            rules.Add(new QuestionRule(4, true, "Replace Switch"));
            rules.Add(new QuestionRule(5, false, 6));
            rules.Add(new QuestionRule(5, true, "Fix or Replace the plug"));
            rules.Add(new QuestionRule(6, false, 10));
            rules.Add(new QuestionRule(6, true, "Fix the cord"));  
            rules.Add(new QuestionRule(7, false, 8));
            rules.Add(new QuestionRule(7, true, 9));
            rules.Add(new QuestionRule(8, true, 9));
            rules.Add(new QuestionRule(8, false, "No Solution!"));
            rules.Add(new QuestionRule(9, false, 3));          
            rules.Add(new QuestionRule(9, true, "Wait For Power come back"));
            rules.Add(new QuestionRule(10, false, "No Solution!"));
            rules.Add(new QuestionRule(10, true, "Fix or replace the outlet"));

            // initialize the expert system
            myExpertSystem = new ExpertSystem(questions, rules);

            //call the next step to ask the question
            nextStep();
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            // Sending the question answer to the expert system object
            myExpertSystem.setQuestionAnswer(true);

            //call the next step to ask the next question or show the final result
            nextStep();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            // Sending the question answer to the expert system object
            myExpertSystem.setQuestionAnswer(false);

            //call the next step to ask the next question or show the final result
            nextStep();
        }


        /**
        * This method used to ask the next question if
        * there is a next quastion, otherwise shows the
        * final result and end appliction
        */
        private void nextStep ()
        {
            questionLabel.Text = myExpertSystem.nextQuestion();

            if (myExpertSystem.getfinalAnswer() != null)
            {
                MessageBox.Show(myExpertSystem.getfinalAnswer(),"Final Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }
    }
}
