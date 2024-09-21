using DoAnPaint.Graphs.Core.Abstract;
using DoAnPaint.Graphs.Core.Interfaces;
using DoAnPaint.Graphs.Models.NinthQuestion;
using System.Collections.Generic;

namespace DoAnPaint.Graphs.Views
{
    public partial class FormNinthQuestion : BaseForm
    {
        public FormNinthQuestion()
        {
            InitializeComponent();
            InitializeModels(new List<IModel> { new FirstModel(), new SecondModel(), new ThirdModel() });
        }
    }
}
