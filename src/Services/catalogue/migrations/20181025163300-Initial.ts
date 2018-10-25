import { QueryInterface, SequelizeStatic, DataTypes } from 'sequelize';

module.exports = {
  // tslint:disable-next-line:variable-name
  up: async (queryInterface: QueryInterface, Sequelize: SequelizeStatic) => {

    queryInterface.createTable('Picture', {
      Id: {
        type: Sequelize.INTEGER,
        allowNull: false,
        primaryKey: true,
        autoIncrement: true
      },
      PictureBinary: {
        type: "VARBINARY",
        allowNull: true
      },
      MimeType: {
        type: Sequelize.STRING,
        allowNull: false
      },
      SeoFilename: {
        type: Sequelize.STRING,
        allowNull: true
      },
      IsNew: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      IsTransient: {
        type: Sequelize.BOOLEAN,
        allowNull: false,
        defaultValue: '0'
      },
      UpdatedOnUtc: {
        type: Sequelize.DATE,
        allowNull: false,
        defaultValue: '1900-01-01T00:00:00.000'
      },
      // MediaStorageId: {
      //   type: Sequelize.INTEGER,
      //   allowNull: true,
      //   references: {
      //     model: 'MediaStorage',
      //     key: 'Id'
      //   }
      // },
      Width: {
        type: Sequelize.INTEGER,
        allowNull: true
      },
      Height: {
        type: Sequelize.INTEGER,
        allowNull: true
      }
    });

    queryInterface.createTable('CategoryTemplate', {
      Id: {
        type: Sequelize.INTEGER,
        allowNull: false,
        primaryKey: true,
        autoIncrement: true
      },
      Name: {
        type: Sequelize.STRING,
        allowNull: false
      },
      ViewPath: {
        type: Sequelize.STRING,
        allowNull: false
      },
      DisplayOrder: {
        type: Sequelize.INTEGER,
        allowNull: false
      }
    });

    queryInterface.createTable("Category", {
      Id: {
        type: Sequelize.INTEGER,
        allowNull: false,
        primaryKey: true,
        autoIncrement: true
      },
      Name: {
        type: Sequelize.STRING,
        allowNull: false
      },
      Description: {
        type: Sequelize.STRING,
        allowNull: true
      },
      Alias: {
        type: Sequelize.STRING,
        allowNull: true
      },
      CategoryTemplateId: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      MetaKeywords: {
        type: Sequelize.STRING,
        allowNull: true
      },
      MetaDescription: {
        type: Sequelize.STRING,
        allowNull: true
      },
      MetaTitle: {
        type: Sequelize.STRING,
        allowNull: true
      },
      ParentCategoryId: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      PictureId: {
        type: Sequelize.INTEGER,
        allowNull: true,
        references: {
          model: 'Picture',
          key: 'Id'
        }
      },

      PageSize: {
        type: Sequelize.INTEGER,
        allowNull: true
      },
      AllowCustomersToSelectPageSize: {
        type: Sequelize.BOOLEAN,
        allowNull: true
      },
      PageSizeOptions: {
        type: Sequelize.STRING,
        allowNull: true
      },
      PriceRanges: {
        type: Sequelize.STRING,
        allowNull: true
      },
      ShowOnHomePage: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      HasDiscountsApplied: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      SubjectToAcl: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      LimitedToStores: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      Published: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      Deleted: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      DisplayOrder: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      CreatedOnUtc: {
        type: Sequelize.DATE,
        allowNull: false
      },
      UpdatedOnUtc: {
        type: Sequelize.DATE,
        allowNull: false
      },
      DefaultViewMode: {
        type: Sequelize.STRING,
        allowNull: true
      },
      FullName: {
        type: Sequelize.STRING,
        allowNull: true
      },
      BottomDescription: {
        type: Sequelize.STRING,
        allowNull: true
      },
      BadgeText: {
        type: Sequelize.STRING,
        allowNull: true
      },
      BadgeStyle: {
        type: Sequelize.INTEGER,
        allowNull: false,
        defaultValue: '((0))'
      }
    });

    queryInterface.createTable('ManufacturerTemplate', {
      Id: {
        type: Sequelize.INTEGER,
        allowNull: false,
        primaryKey: true,
        autoIncrement: true
      },
      Name: {
        type: Sequelize.STRING,
        allowNull: false
      },
      ViewPath: {
        type: Sequelize.STRING,
        allowNull: false
      },
      DisplayOrder: {
        type: Sequelize.INTEGER,
        allowNull: false
      }
    });

    queryInterface.createTable('Manufacturer', {
      Id: {
        type: Sequelize.INTEGER,
        allowNull: false,
        primaryKey: true,
        autoIncrement: true
      },
      Name: {
        type: Sequelize.STRING,
        allowNull: false
      },
      Description: {
        type: Sequelize.STRING,
        allowNull: true
      },
      ManufacturerTemplateId: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      MetaKeywords: {
        type: Sequelize.STRING,
        allowNull: true
      },
      MetaDescription: {
        type: Sequelize.STRING,
        allowNull: true
      },
      MetaTitle: {
        type: Sequelize.STRING,
        allowNull: true
      },
      PictureId: {
        type: Sequelize.INTEGER,
        allowNull: true,
        references: {
          model: 'Picture',
          key: 'Id'
        }
      },
      PageSize: {
        type: Sequelize.INTEGER,
        allowNull: true
      },
      AllowCustomersToSelectPageSize: {
        type: Sequelize.BOOLEAN,
        allowNull: true
      },
      PageSizeOptions: {
        type: Sequelize.STRING,
        allowNull: true
      },
      PriceRanges: {
        type: Sequelize.STRING,
        allowNull: true
      },
      LimitedToStores: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      Published: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      Deleted: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      DisplayOrder: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      CreatedOnUtc: {
        type: Sequelize.DATE,
        allowNull: false
      },
      UpdatedOnUtc: {
        type: Sequelize.DATE,
        allowNull: false
      },
      HasDiscountsApplied: {
        type: Sequelize.BOOLEAN,
        allowNull: false,
        defaultValue: '0'
      }
    });

    queryInterface.createTable('ProductTag', {
      Id: {
        type: Sequelize.INTEGER,
        allowNull: false,
        primaryKey: true,
        autoIncrement: true
      },
      Name: {
        type: Sequelize.STRING,
        allowNull: false
      }
    });

    queryInterface.createTable('ProductAttribute', {
      Id: {
        type: Sequelize.INTEGER,
        allowNull: false,
        primaryKey: true,
        autoIncrement: true
      },
      Alias: {
        type: Sequelize.STRING,
        allowNull: true
      },
      Name: {
        type: Sequelize.STRING,
        allowNull: false
      },
      Description: {
        type: Sequelize.STRING,
        allowNull: true
      },
      AllowFiltering: {
        type: Sequelize.BOOLEAN,
        allowNull: false,
        defaultValue: '1'
      },
      DisplayOrder: {
        type: Sequelize.INTEGER,
        allowNull: false,
        defaultValue: '((0))'
      },
      FacetTemplateHint: {
        type: Sequelize.INTEGER,
        allowNull: false,
        defaultValue: '((0))'
      },
      IndexOptionNames: {
        type: Sequelize.BOOLEAN,
        allowNull: false,
        defaultValue: '0'
      },
      ExportMappings: {
        type: Sequelize.STRING,
        allowNull: true
      }
    });

    queryInterface.createTable('ProductAttributeOptionsSet', {
      Id: {
        type: Sequelize.INTEGER,
        allowNull: false,
        primaryKey: true,
        autoIncrement: true
      },
      Name: {
        type: Sequelize.STRING,
        allowNull: true
      },
      ProductAttributeId: {
        type: Sequelize.INTEGER,
        allowNull: false,
        references: {
          model: 'ProductAttribute',
          key: 'Id'
        }
      }
    });


    queryInterface.createTable('ProductAttributeOption', {
      Id: {
        type: Sequelize.INTEGER,
        allowNull: false,
        primaryKey: true,
        autoIncrement: true
      },
      ProductAttributeOptionsSetId: {
        type: Sequelize.INTEGER,
        allowNull: false,
        references: {
          model: 'ProductAttributeOptionsSet',
          key: 'Id'
        }
      },
      Alias: {
        type: Sequelize.STRING,
        allowNull: true
      },
      Name: {
        type: Sequelize.STRING,
        allowNull: true
      },
      PictureId: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      Color: {
        type: Sequelize.STRING,
        allowNull: true
      },
      PriceAdjustment: {
        type: Sequelize.DECIMAL,
        allowNull: false
      },
      WeightAdjustment: {
        type: Sequelize.DECIMAL,
        allowNull: false
      },
      IsPreSelected: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      DisplayOrder: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      ValueTypeId: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      LinkedProductId: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      Quantity: {
        type: Sequelize.INTEGER,
        allowNull: false
      }
    });

    queryInterface.createTable('Country', {
      Id: {
        type: Sequelize.INTEGER,
        allowNull: false,
        primaryKey: true,
        autoIncrement: true
      },
      Name: {
        type: Sequelize.STRING,
        allowNull: false
      },
      AllowsBilling: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      AllowsShipping: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      TwoLetterIsoCode: {
        type: Sequelize.STRING,
        allowNull: true
      },
      ThreeLetterIsoCode: {
        type: Sequelize.STRING,
        allowNull: true
      },
      NumericIsoCode: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      SubjectToVat: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      Published: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      DisplayOrder: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      LimitedToStores: {
        type: Sequelize.BOOLEAN,
        allowNull: false,
        defaultValue: '0'
      },
      AddressFormat: {
        type: Sequelize.STRING,
        allowNull: true
      }
    });

    queryInterface.createTable('DeliveryTime', {
      Id: {
        type: Sequelize.INTEGER,
        allowNull: false,
        primaryKey: true,
        autoIncrement: true
      },
      Name: {
        type: Sequelize.STRING,
        allowNull: false
      },
      ColorHexValue: {
        type: Sequelize.STRING,
        allowNull: false
      },
      DisplayLocale: {
        type: Sequelize.STRING,
        allowNull: true
      },
      DisplayOrder: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      IsDefault: {
        type: Sequelize.BOOLEAN,
        allowNull: true
      }
    });

    queryInterface.createTable('QuantityUnit', {
      Id: {
        type: Sequelize.INTEGER,
        allowNull: false,
        primaryKey: true,
        autoIncrement: true
      },
      Name: {
        type: Sequelize.STRING,
        allowNull: false
      },
      Description: {
        type: Sequelize.STRING,
        allowNull: true
      },
      DisplayLocale: {
        type: Sequelize.STRING,
        allowNull: true
      },
      DisplayOrder: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      IsDefault: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      }
    });

    queryInterface.createTable('Product', {
      Id: {
        type: Sequelize.INTEGER,
        allowNull: false,
        primaryKey: true,
        autoIncrement: true
      },
      ProductTypeId: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      ParentGroupedProductId: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      VisibleIndividually: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      Name: {
        type: Sequelize.STRING,
        allowNull: false
      },
      ShortDescription: {
        type: Sequelize.STRING,
        allowNull: true
      },
      FullDescription: {
        type: Sequelize.STRING,
        allowNull: true
      },
      AdminComment: {
        type: Sequelize.STRING,
        allowNull: true
      },
      ProductTemplateId: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      ShowOnHomePage: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      MetaKeywords: {
        type: Sequelize.STRING,
        allowNull: true
      },
      MetaDescription: {
        type: Sequelize.STRING,
        allowNull: true
      },
      MetaTitle: {
        type: Sequelize.STRING,
        allowNull: true
      },
      AllowCustomerReviews: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      ApprovedRatingSum: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      NotApprovedRatingSum: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      ApprovedTotalReviews: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      NotApprovedTotalReviews: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      SubjectToAcl: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      LimitedToStores: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      Sku: {
        type: Sequelize.STRING,
        allowNull: true
      },
      ManufacturerPartNumber: {
        type: Sequelize.STRING,
        allowNull: true
      },
      Gtin: {
        type: Sequelize.STRING,
        allowNull: true
      },
      IsGiftCard: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      GiftCardTypeId: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      RequireOtherProducts: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      RequiredProductIds: {
        type: Sequelize.STRING,
        allowNull: true
      },
      AutomaticallyAddRequiredProducts: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      IsDownload: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      DownloadId: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      UnlimitedDownloads: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      MaxNumberOfDownloads: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      DownloadExpirationDays: {
        type: Sequelize.INTEGER,
        allowNull: true
      },
      DownloadActivationTypeId: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      HasSampleDownload: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      HasUserAgreement: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      UserAgreementText: {
        type: Sequelize.STRING,
        allowNull: true
      },
      IsRecurring: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      RecurringCycleLength: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      RecurringCyclePeriodId: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      RecurringTotalCycles: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      IsShipEnabled: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      IsFreeShipping: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      AdditionalShippingCharge: {
        type: Sequelize.DECIMAL,
        allowNull: false
      },
      IsTaxExempt: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      TaxCategoryId: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      ManageInventoryMethodId: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      StockQuantity: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      DisplayStockAvailability: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      DisplayStockQuantity: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      MinStockQuantity: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      LowStockActivityId: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      NotifyAdminForQuantityBelow: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      BackorderModeId: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      AllowBackInStockSubscriptions: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      OrderMinimumQuantity: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      OrderMaximumQuantity: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      AllowedQuantities: {
        type: Sequelize.STRING,
        allowNull: true
      },
      DisableBuyButton: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      DisableWishlistButton: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      AvailableForPreOrder: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      CallForPrice: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      Price: {
        type: Sequelize.DECIMAL,
        allowNull: false
      },
      OldPrice: {
        type: Sequelize.DECIMAL,
        allowNull: false
      },
      ProductCost: {
        type: Sequelize.DECIMAL,
        allowNull: false
      },
      SpecialPrice: {
        type: Sequelize.DECIMAL,
        allowNull: true
      },
      SpecialPriceStartDateTimeUtc: {
        type: Sequelize.DATE,
        allowNull: true
      },
      SpecialPriceEndDateTimeUtc: {
        type: Sequelize.DATE,
        allowNull: true
      },
      CustomerEntersPrice: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      MinimumCustomerEnteredPrice: {
        type: Sequelize.DECIMAL,
        allowNull: false
      },
      MaximumCustomerEnteredPrice: {
        type: Sequelize.DECIMAL,
        allowNull: false
      },
      HasTierPrices: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      HasDiscountsApplied: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      Weight: {
        type: Sequelize.DECIMAL,
        allowNull: false
      },
      Length: {
        type: Sequelize.DECIMAL,
        allowNull: false
      },
      Width: {
        type: Sequelize.DECIMAL,
        allowNull: false
      },
      Height: {
        type: Sequelize.DECIMAL,
        allowNull: false
      },
      AvailableStartDateTimeUtc: {
        type: Sequelize.DATE,
        allowNull: true
      },
      AvailableEndDateTimeUtc: {
        type: Sequelize.DATE,
        allowNull: true
      },
      DisplayOrder: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      Published: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      Deleted: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      CreatedOnUtc: {
        type: Sequelize.DATE,
        allowNull: false
      },
      UpdatedOnUtc: {
        type: Sequelize.DATE,
        allowNull: false
      },
      DeliveryTimeId: {
        type: Sequelize.INTEGER,
        allowNull: true,
        references: {
          model: 'DeliveryTime',
          key: 'Id'
        }
      },
      BasePriceEnabled: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      BasePriceMeasureUnit: {
        type: Sequelize.STRING,
        allowNull: true
      },
      BasePriceAmount: {
        type: Sequelize.DECIMAL,
        allowNull: true
      },
      BasePriceBaseAmount: {
        type: Sequelize.INTEGER,
        allowNull: true
      },
      BundleTitleText: {
        type: Sequelize.STRING,
        allowNull: true
      },
      BundlePerItemShipping: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      BundlePerItemPricing: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      BundlePerItemShoppingCart: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      LowestAttributeCombinationPrice: {
        type: Sequelize.DECIMAL,
        allowNull: true
      },
      IsEsd: {
        type: Sequelize.BOOLEAN,
        allowNull: false,
        defaultValue: '0'
      },
      QuantityUnitId: {
        type: Sequelize.INTEGER,
        allowNull: true,
        references: {
          model: 'QuantityUnit',
          key: 'Id'
        }
      },
      HomePageDisplayOrder: {
        type: Sequelize.INTEGER,
        allowNull: false,
        defaultValue: '((0))'
      },
      QuantityStep: {
        type: Sequelize.INTEGER,
        allowNull: false,
        defaultValue: '((0))'
      },
      QuantiyControlType: {
        type: Sequelize.INTEGER,
        allowNull: false,
        defaultValue: '((0))'
      },
      HideQuantityControl: {
        type: Sequelize.BOOLEAN,
        allowNull: false,
        defaultValue: '0'
      },
      CustomsTariffNumber: {
        type: Sequelize.STRING,
        allowNull: true
      },
      CountryOfOriginId: {
        type: Sequelize.INTEGER,
        allowNull: true,
        references: {
          model: 'Country',
          key: 'Id'
        }
      },
      MainPictureId: {
        type: Sequelize.INTEGER,
        allowNull: true
      },
      IsSystemProduct: {
        type: Sequelize.BOOLEAN,
        allowNull: false,
        defaultValue: '0'
      },
      SystemName: {
        type: Sequelize.STRING,
        allowNull: true
      },
      HasPreviewPicture: {
        type: Sequelize.BOOLEAN,
        allowNull: false,
        defaultValue: '0'
      }
    });

    queryInterface.createTable('Product_Category_Mapping', {
      Id: {
        type: Sequelize.INTEGER,
        allowNull: false,
        primaryKey: true,
        autoIncrement: true
      },
      ProductId: {
        type: Sequelize.INTEGER,
        allowNull: false,
        references: {
          model: 'Product',
          key: 'Id'
        }
      },
      CategoryId: {
        type: Sequelize.INTEGER,
        allowNull: false,
        references: {
          model: 'Category',
          key: 'Id'
        }
      },
      IsFeaturedProduct: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      DisplayOrder: {
        type: Sequelize.INTEGER,
        allowNull: false
      }
    });

    queryInterface.createTable('Product_Manufacturer_Mapping', {
      Id: {
        type: Sequelize.INTEGER,
        allowNull: false,
        primaryKey: true,
        autoIncrement: true
      },
      ProductId: {
        type: Sequelize.INTEGER,
        allowNull: false,
        references: {
          model: 'Product',
          key: 'Id'
        }
      },
      ManufacturerId: {
        type: Sequelize.INTEGER,
        allowNull: false,
        references: {
          model: 'Manufacturer',
          key: 'Id'
        }
      },
      IsFeaturedProduct: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      DisplayOrder: {
        type: Sequelize.INTEGER,
        allowNull: false
      }
    });

    queryInterface.createTable('Product_Picture_Mapping', {
      Id: {
        type: Sequelize.INTEGER,
        allowNull: false,
        primaryKey: true,
        autoIncrement: true
      },
      ProductId: {
        type: Sequelize.INTEGER,
        allowNull: false,
        references: {
          model: 'Product',
          key: 'Id'
        }
      },
      PictureId: {
        type: Sequelize.INTEGER,
        allowNull: false,
        references: {
          model: 'Picture',
          key: 'Id'
        }
      },
      DisplayOrder: {
        type: Sequelize.INTEGER,
        allowNull: false
      }
    });

    queryInterface.createTable('Product_ProductAttribute_Mapping', {
      Id: {
        type: Sequelize.INTEGER,
        allowNull: false,
        primaryKey: true,
        autoIncrement: true
      },
      ProductId: {
        type: Sequelize.INTEGER,
        allowNull: false,
        references: {
          model: 'Product',
          key: 'Id'
        }
      },
      ProductAttributeId: {
        type: Sequelize.INTEGER,
        allowNull: false,
        references: {
          model: 'ProductAttribute',
          key: 'Id'
        }
      },
      TextPrompt: {
        type: Sequelize.STRING,
        allowNull: true
      },
      IsRequired: {
        type: Sequelize.BOOLEAN,
        allowNull: false
      },
      AttributeControlTypeId: {
        type: Sequelize.INTEGER,
        allowNull: false
      },
      DisplayOrder: {
        type: Sequelize.INTEGER,
        allowNull: false
      }
    });

    queryInterface.createTable('Product_ProductTag_Mapping', {
      Product_Id: {
        type: Sequelize.INTEGER,
        allowNull: false,
        primaryKey: true,
        references: {
          model: 'Product',
          key: 'Id'
        }
      },
      ProductTag_Id: {
        type: Sequelize.INTEGER,
        allowNull: false,
        primaryKey: true,
        references: {
          model: 'ProductTag',
          key: 'Id'
        }
      }
    });

  },


  // tslint:disable-next-line:variable-name
  down: async (queryInterface: QueryInterface, Sequelize: SequelizeStatic) => {
    queryInterface.dropTable("Product_ProductTag_Mapping");
    queryInterface.dropTable("Product_ProductAttribute_Mapping");
    queryInterface.dropTable("Product_Picture_Mapping");
    queryInterface.dropTable("Product_Manufacturer_Mapping");
    queryInterface.dropTable("Product_Category_Mapping");
    queryInterface.dropTable("Product");
  
    queryInterface.dropTable("ProductTag");
    queryInterface.dropTable("Manufacturer");
    queryInterface.dropTable("ManufacturerTemplate");
    queryInterface.dropTable("Category");
    queryInterface.dropTable("CategoryTemplate");
    queryInterface.dropTable("Picture");

    queryInterface.dropTable("QuantityUnit");
    queryInterface.dropTable("DeliveryTime");
    queryInterface.dropTable("Country");
    queryInterface.dropTable("ProductAttributeOption");
    queryInterface.dropTable("ProductAttributeOptionsSet");
    queryInterface.dropTable("ProductAttribute");

  },
};