using IOPath = System.IO.Path;

namespace MarioTravel.Core.BLL.Services.EmailTemplate.Service.TemplateRegister
{
    public static class TransferTemplates
    {
        private const string TEMPLATE_PATH = "~/App/Infrastructure/EmailTemplates";

        public static class Email
        {
            private const string EMAIL_PATH = "TemplateDesign/";

            public static class DepositTransferPaymentApproved
            {
                public static readonly string Name = nameof(DepositTransferPaymentApproved);

                public static readonly string Path = IOPath.Combine(TEMPLATE_PATH, EMAIL_PATH,
                    "DepositTransferPaymentApproved.template");
            }

            public static class DepositTransferPaymentDeclined
            {
                public static readonly string Name = nameof(DepositTransferPaymentDeclined);

                public static readonly string Path = IOPath.Combine(TEMPLATE_PATH, EMAIL_PATH,
                    "DepositTransferPaymentDeclined.template");
            }

            public static class DepositTransferPaymentNotCompleted
            {
                public static readonly string Name = nameof(DepositTransferPaymentNotCompleted);

                public static readonly string Path = IOPath.Combine(TEMPLATE_PATH, EMAIL_PATH,
                    "DepositTransferPaymentNotCompleted.template");
            }

            public static class FullTransferPaymentApproved
            {
                public static readonly string Name = nameof(FullTransferPaymentApproved);

                public static readonly string Path = IOPath.Combine(TEMPLATE_PATH, EMAIL_PATH,
                    "FullTransferPaymentApproved.template");
            }

            public static class FullTransferPaymentDeclined
            {
                public static readonly string Name = nameof(FullTransferPaymentDeclined);

                public static readonly string Path = IOPath.Combine(TEMPLATE_PATH, EMAIL_PATH,
                    "FullTransferPaymentDeclined.template");
            }

            public static class FullTransferPaymentNotCompleted
            {
                public static readonly string Name = nameof(FullTransferPaymentNotCompleted);

                public static readonly string Path = IOPath.Combine(TEMPLATE_PATH, EMAIL_PATH,
                    "FullTransferPaymentNotCompleted.template");
            }
        }
    }
}