import { Table, Column, Model, PrimaryKey, AutoIncrement, DataType, AllowNull, ForeignKey, BelongsTo, Scopes } from 'sequelize-typescript';

@Table({ tableName: 'Product' })

export class Product extends Model<Product> {

    @PrimaryKey  
    @AutoIncrement  
    @AllowNull(false)    
    @Column({ type: DataType.INTEGER})
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
    RecurringCycl
