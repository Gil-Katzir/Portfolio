using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabin_School
{
    public class ExternalActivity
    {
        private int activityId;
        private DateTime startDate;
        private int numOfParticipants;
        private float cost;
        private ActivityTypes activityType;
        private DateTime endDateTime;
        public List<Student> students_invited;
        public List<ConsentForm> students_consent_forms;
        

        public ExternalActivity(int activityId, DateTime startDate, int numOfParticipants, float cost, ActivityTypes activityType, DateTime endDateTime)
        {
            this.activityId = activityId;
            this.startDate = startDate;
            this.numOfParticipants = numOfParticipants;
            this.cost = cost;
            this.activityType = activityType;
            this.endDateTime = endDateTime;
            this.students_invited = new List<Student>();
            this.students_consent_forms = new List<ConsentForm>();
        }

        public int get_id()
        {
            return this.activityId;
        }

        public DateTime get_startDate()
        {
            return this.startDate;
        }

        public DateTime get_endDateTime()
        {
            return this.endDateTime;
        }

        public ActivityTypes get_activityType()
        {
            return this.activityType;
        }

        public float get_cost()
        {
            return this.cost;
        }

        public void add_student_consent_form(ConsentForm c_f)
        {
            this.students_consent_forms.Add(c_f);
        }
    }
}
