using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Topic
    {
        private String title;
        private String description;
        private String inputExample;
        private String outputExample;
        private String[] inputText;
        private String[] outputText;
        private String answer;
        private String creater;
        private String password;

        public Topic() {
            title = null;
            description = null;
            inputExample = null;
            outputExample = null;
            inputText = null;
            outputText = null;
            answer = null;
            creater = null;
            password = null;
        }



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

        public string Creater
        {
            get
            {
                return creater;
            }

            set
            {
                creater = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string ToString()
        {
            String res = "";
            res += "\n creater: " + creater;
            res += "\n password: " + password;
            res += "\n title: " + title;
            res += "\n description: " + description;
            res += "\n inputExample: " + inputExample;
            res += "\n outputExample: " + outputExample;
            foreach (String txt in inputText)
            {
                res += "\n inputText: " + txt;
            }
            foreach (String txt in outputText)
            {
                res += "\n outputText: " + txt;
            }
            res += "\n";
            return res;
        }
    }
}
