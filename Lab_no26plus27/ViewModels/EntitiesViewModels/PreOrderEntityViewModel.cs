using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_no25.Model.Entities;
using Prism.Mvvm;

namespace Lab_no26plus27.ViewModels.EntitiesViewModels
{
    public class PreOrderEntityViewModel : BindableBase
    {
        private PreOrderEntity _entity;

        public PreOrderEntityViewModel(PreOrderEntity entity)
        {
            _entity = entity;
        }

        public PreOrderEntity Entity { get => _entity; set => SetProperty(ref _entity, value); }
    }
}
