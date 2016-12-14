using System.Collections.Generic;

namespace ExpertSystemLamp
{
    public class ExpertSystem
    {
        int currentQuestionId = 1;
        int lastQuestionId = 0;
        bool lastAnswer = false;

        string finalAnswer = null;

        List<Question> QuestionsList;
        List<QuestionRule> QuestionsRules;

        public ExpertSystem (List<Question> QurstionsList, List<QuestionRule> QuestionsRules)
        {
            this.QuestionsList = QurstionsList;
            this.QuestionsRules = QuestionsRules;
        }

        public string nextQuestion ()
        {
            if (currentQuestionId == 1)
            {
                currentQuestionId++;
                lastQuestionId++;
                return getQuestionText(1);
            }
            else
            {
                foreach (QuestionRule rule in QuestionsRules)
                {
                    if (rule.parentQuestionId == lastQuestionId && rule.parentQuestionAnswer == lastAnswer)
                    {
                        if (rule.finalAnswer != null)
                        {
                            finalAnswer = rule.finalAnswer;
                        }
                        else
                        {
                            currentQuestionId++;
                            lastQuestionId = rule.questionId;
                            return getQuestionText(rule.questionId);
                        }                    
                    }
                }
                return null;
            }
        }

        public string getfinalAnswer ()
        {
            return this.finalAnswer;
        }

        public void setQuestionAnswer (bool answer)
        {
            this.lastAnswer = answer;
        }

        private string getQuestionText (int id)
        {
            Question question = this.QuestionsList.Find(x => x.questionId == id);
            return question.questionText;
        }
    }

    public class Question
    {
 
        public Question (int questionId, string questionText)
        {
            this.questionId = questionId;
            this.questionText = questionText;
        }

        public int questionId { get; set; }
        public string questionText { get; set; }
    }

    public class QuestionAnswer
    {

        public QuestionAnswer(int questionId, bool questionAnswer)
        {
            this.questionId = questionId;
            this.questionAnswer = questionAnswer;
        }

        public int questionId { get; set; }
        public bool questionAnswer { get; set; }
    }

    public class QuestionRule
    {

        public QuestionRule(int parentQuestionId, bool parentQuestionAnswer, int questionId)
        {
            this.questionId = questionId;
            this.parentQuestionId = parentQuestionId;
            this.parentQuestionAnswer = parentQuestionAnswer;
        }

        public QuestionRule(int parentQuestionId, bool parentQuestionAnswer, string finalAnswer)
        {
            this.parentQuestionId = parentQuestionId;
            this.finalAnswer = finalAnswer;
            this.parentQuestionAnswer = parentQuestionAnswer;
        }

        public int questionId { get; set; }
        public int parentQuestionId { get; set; }
        public bool parentQuestionAnswer { get; set; }
        public string finalAnswer { get; set; }
    }
}
