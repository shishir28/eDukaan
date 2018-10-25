import { Table, Column, Model, PrimaryKey, AutoIncrement, DataType, AllowNull, ForeignKey, BelongsTo, Scopes } from 'sequelize-typescript';

@Table({ tableName: 'Country' })

export class Country extends Model<Country> {
    @PrimaryKey  
    @AutoIncrement  
    @AllowNull(false)    
    @Column({ type: DataType.INTEGER})
    Id: number

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    Name: string

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    AllowsBilling: boolean

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    AllowsShipping: boolean

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    TwoLetterIsoCode: string

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    ThreeLetterIsoCode: string

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    NumericIsoCode: number

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    SubjectToVat: boolean

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    Published: boolean

    @AllowNull(false)
    @Column({ type: DataType.INTEGER })
    DisplayOrder: number

    @AllowNull(false)
    @Column({ type: DataType.BOOLEAN })
    LimitedToStores: boolean

    @AllowNull(false)
    @Column({ type: DataType.STRING })
    AddressFormat: string
}
