import { Table, Column, Model, PrimaryKey, AutoIncrement, DataType, AllowNull, ForeignKey, BelongsTo, Scopes } from 'sequelize-typescript';

@Table({ tableName: 'DeliveryTime' })

export class DeliveryTime extends Model<DeliveryTime> {

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
    ColorHexValue: string

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    DisplayLocale: string

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    DisplayOrder: number

    @AllowNull(true)
    @Column({ type: DataType.BOOLEAN })
    IsDefault: boolean
}