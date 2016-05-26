using System;

public class CSharpExam : Exam
{
    private const int ScoreMinValue = 0;
    private const int ScoreMaxValue = 100;
    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }

        private set
        {
            if (value < ScoreMinValue || value > ScoreMaxValue)
            {
                throw new ArgumentOutOfRangeException(string.Format("Score should be a value between {0} and {1}", ScoreMinValue, ScoreMaxValue));
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, ScoreMinValue, ScoreMaxValue, "Exam results calculated by score.");
    }
}
