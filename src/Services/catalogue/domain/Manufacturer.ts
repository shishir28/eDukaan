import { Table, Column, Model, PrimaryKey, AutoIncrement, DataType, AllowNull, ForeignKey, BelongsTo, Scopes } from 'sequelize-typescript';

@Table({ tableName: 'Manufacturer' })

export class Manufacturer extends Model<Manufacturer> {

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
    @Column({ type: DataType.INTEGER })
    ManufacturerTemplateId: number

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    MetaKeywords: string

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    MetaDescription: string

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    MetaTitle: string

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
    @Column({ type: DataType.BOOLEAN })
    HasDiscountsApplied: boolean
}
