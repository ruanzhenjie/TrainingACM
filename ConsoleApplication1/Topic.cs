using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Topic
    {
        private String title;
        private String description;
        private String inputExample;
        private String outputExample;
        private String[] inputText;
        private String[] outputText;
        private String answer;

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string InputExample
        {
            get
            {
                return inputExample;
            }

            set
            {
                inputExample = value;
            }
        }

        public string OutputExample
        {
            get
            {
                return outputExample;
            }

            set
            {
                outputExample = value;
            }
        }

        public String[] InputText
        {
            get
            {
                return inputText;
            }

            set
            {
                inputText = value;
            }
        }

        public String[] OutputText
        {
            get
            {
                return outputText;
            }

            set
            {
                outputText = value;
            }
        }

        public string Answer
        {
            get
            {
                return answer;
            }

            set
            {
                answer = value;
            }
        }
    }
}
