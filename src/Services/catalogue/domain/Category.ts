import { Table, Column, Model, PrimaryKey, AutoIncrement, DataType, AllowNull, ForeignKey, BelongsTo, Scopes } from 'sequelize-typescript';

@Table({ tableName: 'Category' })

export class Category extends Model<Category> {

    @PrimaryKey  
    @AutoIncrement  
    @AllowNull(false)    
    @Column({ type: DataType.INTEGER})
    Id: number

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    Name: string

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    Description: string

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    Alias: string

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    CategoryTemplateId: number

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
    @Column({ type: DataType.INTEGER })
    ParentCategoryId: number

    @AllowNull(true)
    @Column({ type: DataType.INTEGER })
    PictureId: number

    @AllowNull(true)
    @Column({ type: DataType.INTEGER })
    PageSize: number

    @AllowNull(true)
    @Column({ type: DataType.BOOLEAN })
    AllowCustomersToSelectPageSize: boolean

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    PageSizeOptions: string

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    PriceRanges: string

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    ShowOnHomePage: boolean

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    HasDiscountsApplied: boolean

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    SubjectToAcl: boolean

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    LimitedToStores: boolean

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    Published: boolean

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    Deleted: boolean

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    DisplayOrder: number

    @AllowNull(false)
    @Column({ type: DataType.DATE })
    CreatedOnUtc: Date

    @AllowNull(false)
    @Column({ type: DataType.DATE })
    UpdatedOnUtc: Date

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    DefaultViewMode: string

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    FullName: string

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    BottomDescription: string

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    BadgeText: string

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    BadgeStyle: number
}
