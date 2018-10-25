import { Table, Column, Model, PrimaryKey, AutoIncrement, DataType, AllowNull, ForeignKey, BelongsTo, Scopes } from 'sequelize-typescript';

@Table({ tableName: 'ManufacturerTemplate' })

export class ManufacturerTemplate extends Model<ManufacturerTemplate> {

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
    ViewPath: string

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    DisplayOrder: number
}
