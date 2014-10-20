﻿using Bukimedia.PrestaSharp.Factories;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Bukimedia.PrestaSharp.Factories
{
    public class ImageFactory : RestSharpFactory
    {
        public ImageFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        #region Protected methods

        protected List<Entities.image> GetAllImages(string Resource){
            RestRequest request = this.RequestForFilter("images/" + Resource, "full", null, null, null, "images");
            return this.Execute<List<Entities.image>>(request);
        }

        protected List<Entities.FilterEntities.declination> GetImagesByInstance(string Resource, long Id)
        {
            RestRequest request = this.RequestForFilter("images/" + Resource + "/" + Id, "full", null, null, null, "image");
            List<Entities.FilterEntities.declination> Declinations = this.Execute<List<Entities.FilterEntities.declination>>(request);
            List<Entities.FilterEntities.declination> AuxDeclinations = new List<Entities.FilterEntities.declination>();
            foreach (Entities.FilterEntities.declination Declination in Declinations)
            {
                if (!AuxDeclinations.Contains(Declination))
                {
                    AuxDeclinations.Add(Declination);
                }
            }
            return AuxDeclinations;
        }

        protected Entities.image AddImage(string Resource, long? Id, string ImagePath)
        {
            RestRequest request = this.RequestForAddImage(Resource, Id, ImagePath);
            return this.Execute<Entities.image>(request);
        }

        protected Entities.image AddImage(string Resource, long? Id, byte[] Image)
        {
            RestRequest request = this.RequestForAddImage(Resource, Id, Image);
            return this.Execute<Entities.image>(request);
        }

        protected void UpdateImage(string Resource, long? ResourceId, long? ImageId, string ImagePath)
        {
            this.DeleteImage(Resource, ResourceId,ImageId);
            this.AddImage(Resource, ResourceId, ImagePath);
        }

        protected void DeleteImage(string Resource, long? ResourceId, long? ImageId)
        {
            RestRequest request = this.RequestForDeleteImage(Resource, ResourceId, ImageId);
            this.Execute<Entities.image>(request);
        }

        #endregion Protected methods

        #region Manufacturer images

        public List<Entities.image> GetAllManufacturerImages()
        {
            return this.GetAllImages("manufacturers");
        }

        public void AddManufacturerImage(long ManufacturerId, string ManufacturerImagePath)
        {
            this.AddImage("manufacturers", ManufacturerId, ManufacturerImagePath);
        }
        
        public void AddManufacturerImage(long ManufacturerId, byte[] ManufacturerImage)
        {
            this.AddImage("manufacturers", ManufacturerId, ManufacturerImage);
        }

        public void UpdateManufacturerImage(long ManufacturerId, string ManufacturerImagePath)
        {
            this.UpdateImage("manufacturers", ManufacturerId, null, ManufacturerImagePath);
        }

        public void DeleteManufacturerImage(long ManufacturerID)
        {
            this.DeleteImage("manufacturers", ManufacturerID, null);
        }

        #endregion Manufacturer images

        #region Product images

        public List<Entities.image> GetAllProductImages()
        {
            return this.GetAllImages("products");
        }

        public List<Entities.FilterEntities.declination> GetProductImages(long ProductId)
        {
            return this.GetImagesByInstance("products", ProductId);
        }

        public Entities.image AddProductImage(long ProductId, string ProductImagePath)
        {
            return this.AddImage("products", ProductId, ProductImagePath);
        }

        public Entities.image AddProductImage(long ProductId, byte[] ProductImage)
        {
            return this.AddImage("products", ProductId, ProductImage);
        }

        public void UpdateProductImage(long ProductId, long ImageId, string ProductImagePath)
        {
            this.UpdateImage("products", ProductId, ImageId, ProductImagePath);
        }

        public void DeleteProductImage(long ProductId,long ImageId)
        {
            this.DeleteImage("products", ProductId, ImageId);
        }

        #endregion Product images

        #region Category images

        public List<Entities.image> GetAllCategoryImages()
        {
            return this.GetAllImages("categories");
        }

        public void AddCategoryImage(long? CategoryId, string CategoryImagePath)
        {
            this.AddImage("categories", CategoryId, CategoryImagePath);
        }
        
        public void AddCategoryImage(long? CategoryId, byte[] CategoryImage)
        {
            this.AddImage("categories", CategoryId, CategoryImage);
        }

        public void UpdateCategoryImage(long CategoryId, string CategoryImagePath)
        {
            this.UpdateImage("categories", CategoryId, null, CategoryImagePath);
        }

        public void DeleteCategoryImage(long CategoryID)
        {
            this.DeleteImage("categories", CategoryID, null);
        }

        #endregion Category images

    }
}