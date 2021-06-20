using IOPath = System.IO.Path;

namespace MarioTravel.Core.BLL.Services.EmailTemplate.Service.TemplateRegister
{
    public static class TourTemplates
    {
        private const string TEMPLATE_PATH = "~/App/Infrastructure/EmailTemplates";

        public static class Email
        {
            private const string EMAIL_PATH = "TemplateDesign/";

            public static class DepositTourPaymentApproved
            {
                public static readonly string Name = nameof(DepositTourPaymentApproved);

                public static readonly string Path = IOPath.Combine(TEMPLATE_PATH, EMAIL_PATH,
                    "DepositTourPaymentApproved.template");
            }

            public static class DepositTourPaymentDeclined
            {
                public static readonly string Name = nameof(DepositTourPaymentDeclined);

                public static readonly string Path = IOPath.Combine(TEMPLATE_PATH, EMAIL_PATH,
                    "DepositTourPaymentDeclined.template");
            }

            public static class DepositTourPaymentNotCompleted
            {
                public static readonly string Name = nameof(DepositTourPaymentNotCompleted);

                public static readonly string Path = IOPath.Combine(TEMPLATE_PATH, EMAIL_PATH,
                    "DepositTourPaymentNotCompleted.template");
            }

            public static class FullTourPaymentApproved
            {
                public static readonly string Name = nameof(FullTourPaymentApproved);

                public static readonly string Path = IOPath.Combine(TEMPLATE_PATH, EMAIL_PATH,
                    "FullTourPaymentApproved.template");
            }

            public static class FullTourPaymentDeclined
            {
                public static readonly string Name = nameof(FullTourPaymentDeclined);

                public static readonly string Path = IOPath.Combine(TEMPLATE_PATH, EMAIL_PATH,
                    "FullTourPaymentDeclined.template");
            }

            public static class FullTourPaymentNotCompleted
            {
                public static readonly string Name = nameof(FullTourPaymentNotCompleted);

                public static readonly string Path = IOPath.Combine(TEMPLATE_PATH, EMAIL_PATH,
                    "FullTourPaymentNotCompleted.template");
            }
        }
    }
}