import { Table, Column, Model, PrimaryKey, AutoIncrement, DataType, AllowNull, ForeignKey, BelongsTo, Scopes } from 'sequelize-typescript';

@Table({ tableName: 'Product' })

export class Product extends Model<Product> {

    @PrimaryKey
    @AutoIncrement
    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    Id: number

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    ProductTypeId: number

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    ParentGroupedProductId: number

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    VisibleIndividually: boolean

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    Name: string

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    ShortDescription: string

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    FullDescription: string

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    AdminComment: string

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    ProductTemplateId: number

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    ShowOnHomePage: boolean

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    MetaKeywords: string

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    MetaDescription: string

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    MetaTitle: string

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    AllowCustomerReviews: boolean

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    ApprovedRatingSum: number

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    NotApprovedRatingSum: number

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    ApprovedTotalReviews: number

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    NotApprovedTotalReviews: number

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    SubjectToAcl: boolean

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    LimitedToStores: boolean

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    Sku: string

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    ManufacturerPartNumber: string

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    Gtin: string

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    IsGiftCard: boolean

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    GiftCardTypeId: number

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    RequireOtherProducts: boolean

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    RequiredProductIds: string

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    AutomaticallyAddRequiredProducts: boolean

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    IsDownload: boolean

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    DownloadId: number

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    UnlimitedDownloads: boolean

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    MaxNumberOfDownloads: number

    @AllowNull(true)
    @Column({ type: DataType.INTEGER })
    DownloadExpirationDays: number

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    DownloadActivationTypeId: number

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    HasSampleDownload: boolean

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    HasUserAgreement: boolean

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    UserAgreementText: string

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    IsRecurring: boolean


    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    RecurringCycleLength: number

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    RecurringCyclePeriodId: number

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    RecurringTotalCycles: number

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    IsShipEnabled: boolean

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    IsFreeShipping: boolean

    @AllowNull(false)
    @Column({ type: DataType.DECIMAL })
    AdditionalShippingCharge: Number

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    IsTaxExempt: boolean

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    TaxCategoryId: number

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    ManageInventoryMethodId: number

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    StockQuantity: number

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    DisplayStockAvailability: boolean

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    DisplayStockQuantity: boolean

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    MinStockQuantity: number

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    LowStockActivityId: number

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    NotifyAdminForQuantityBelow: number

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    BackorderModeId: number

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    AllowBackInStockSubscriptions: boolean

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    OrderMinimumQuantity: number

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    OrderMaximumQuantity: number

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    AllowedQuantities: string

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    DisableBuyButton: boolean

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    DisableWishlistButton: boolean

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    AvailableForPreOrder: boolean

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    CallForPrice: boolean

    @AllowNull(false)
    @Column({ type: DataType.DECIMAL })
    Price: Number

    @AllowNull(false)
    @Column({ type: DataType.DECIMAL })
    OldPrice: Number

    @AllowNull(false)
    @Column({ type: DataType.DECIMAL })
    ProductCost: Number

    @AllowNull(true)
    @Column({ type: DataType.DECIMAL })
    SpecialPrice: Number

    @AllowNull(true)
    @Column({ type: DataType.DATE })
    SpecialPriceStartDateTimeUtc: Date

    @AllowNull(true)
    @Column({ type: DataType.DATE })
    SpecialPriceEndDateTimeUtc: Date

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    CustomerEntersPrice: boolean

    @AllowNull(false)
    @Column({ type: DataType.DECIMAL })
    MinimumCustomerEnteredPrice: Number

    @AllowNull(false)
    @Column({ type: DataType.DECIMAL })
    MaximumCustomerEnteredPrice: Number

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    HasTierPrices: boolean

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    HasDiscountsApplied: boolean

    @AllowNull(false)
    @Column({ type: DataType.DECIMAL })
    Weight: Number

    @AllowNull(false)
    @Column({ type: DataType.DECIMAL })
    Length: Number

    @AllowNull(false)
    @Column({ type: DataType.DECIMAL })
    Width: Number

    @AllowNull(false)
    @Column({ type: DataType.DECIMAL })
    Height: Number
    
    @AllowNull(true)
    @Column({ type: DataType.DATE })
    AvailableStartDateTimeUtc: Date

    @AllowNull(true)
    @Column({ type: DataType.DATE })
    AvailableEndDateTimeUtc: Date

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    DisplayOrder: number

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    Published: boolean

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    Deleted: boolean

    @AllowNull(false)
    @Column({ type: DataType.DATE })
    CreatedOnUtc: Date

    @AllowNull(false)
    @Column({ type: DataType.DATE })
    UpdatedOnUtc: Date

    @AllowNull(true)
    @Column({ type: DataType.INTEGER })
    DeliveryTimeId: number

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    BasePriceEnabled: boolean

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    BasePriceMeasureUnit: string

    @AllowNull(true)
    @Column({ type: DataType.DECIMAL })
    BasePriceAmount:Number

    @AllowNull(true)
    @Column({ type: DataType.INTEGER })
    BasePriceBaseAmount: number

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    BundleTitleText: string

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    BundlePerItemShipping: boolean

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    BundlePerItemPricing: boolean

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    BundlePerItemShoppingCart: boolean

    @AllowNull(true)
    @Column({ type: DataType.DECIMAL })
    LowestAttributeCombinationPrice: Number

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    IsEsd: boolean

    @AllowNull(true)
    @Column({ type: DataType.INTEGER })
    QuantityUnitId: number

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    HomePageDisplayOrder: number

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    QuantityStep: number

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    QuantiyControlType: number

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    HideQuantityControl: boolean

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    CustomsTariffNumber: string

    @AllowNull(true)
    @Column({ type: DataType.INTEGER })
    CountryOfOriginId: number

    @AllowNull(true)
    @Column({ type: DataType.INTEGER })
    MainPictureId: number

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    IsSystemProduct: boolean

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    SystemName: string

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    HasPreviewPicture: boolean
}