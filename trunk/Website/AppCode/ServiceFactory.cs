using G9.Service;
using G9.Impl;

namespace App_Code
{
    public class ServiceFactory
    {
        #region Customer
        private static ICustomer _customer;
        public static ICustomer GetInstanceCustomer()
        {
            return _customer ?? (_customer = new CustomerImpl());
        }
        #endregion Customer

        #region GetInstanceIproductType
        private static IProductType _iProductType;
        public static IProductType GetInstanceIproductType()
        {
            return _iProductType ?? (_iProductType = new ProductTypeImpl());
        }
        #endregion GetInstanceIproductType

        #region GetInstanceProduct
        private static IProducts _products;
        public static IProducts GetInstanceProduct()
        {
            return _products ?? (_products = new ProductsImpl());
        }
        #endregion GetInstanceProduct

        #region GetInstanceUser
        private static IUser _iUser;
        public static IUser GetInstanceUser()
        {
            return _iUser ?? (_iUser = new UserImpl());
        }
        #endregion GetInstanceUser

        #region GetInstanceRole
        private static IRole _irole;
        public static IRole GetInstanceRole()
        {
            return _irole ?? (_irole = new RoleImpl());
        }
        #endregion GetInstanceRole

        #region GetInstanceNews
        private static INews _news;
        public static INews GetInstanceNews()
        {
            return _news ?? (_news = new NewsImpl());
        }
        #endregion GetInstanceNews

        #region GetInstanceCategoryType
        private static ICategoryType _categoryType;
        public static ICategoryType GetInstanceCategoryType()
        {
            return _categoryType ?? (_categoryType = new CategoryTypeImpl());
        }
        #endregion GetInstanceCategoryType

        #region GetInstanceSupport
        private static ISupport _support;
        public static ISupport GetInstanceSupport()
        {
            return _support ?? (_support = new SupportImpl());
        }
        #endregion GetInstanceSupport

        #region GetInstanceComment

        private static ICusComment _comment;
        public static ICusComment GetInstanceComment()
        {
            return _comment ?? (_comment = new CusCommentImpl());
        }
        #endregion

        #region GetInstanceContac
        private static IContact _icont;
        public static IContact GetInstanceContact()
        {
            return _icont ?? (_icont = new ContactImpl());
        }
        #endregion GetInstanceComment

        #region GetInstanceProductDetail
        private static IProductDetail _IProduct;
        public static IProductDetail GetInstanceProductDetail()
        {
            return _IProduct ?? (_IProduct = new ProductDetailImpl());
        }
        #endregion GetInstanceProductDetail
    }
}