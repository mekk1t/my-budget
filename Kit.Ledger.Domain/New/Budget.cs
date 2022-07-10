using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kit.Ledger.Domain.New
{
    /// <summary>
    /// Месячный бюджет.
    /// </summary>
    public class Budget
    {
        // Общий флоу: Первая ревизия --> Вторая ревизия --> Бюджет --> Первая ревизия...

        /// <summary>
        /// Месяц, за который составлена статистика.
        /// </summary>
        public Month Month { get; set; }

        /// <summary>
        /// Первая ревизия, формируется в начале месяца.
        /// </summary>
        public Revision FirstRevision { get; set; }
        /// <summary>
        /// Вторая ревизия, формируется в конце месяца.
        /// </summary>
        public Revision SecondRevision { get; set; }

        /// <summary>
        /// Начало периода статистики.
        /// </summary>
        public DateTime BeginsAt => FirstRevision.CreatedAt;
        /// <summary>
        /// Конец периода статистики.
        /// </summary>
        public DateTime EndsAt => SecondRevision.CreatedAt;
    }
}
