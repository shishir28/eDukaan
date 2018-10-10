import { Table, Column, Model, PrimaryKey, AutoIncrement, DataType, AllowNull, ForeignKey, BelongsTo, Scopes } from 'sequelize-typescript';

  
@Table({ tableName: 'Product' })
export class Product extends Model<Product> {

    @PrimaryKey  
    @AutoIncrement  
    @AllowNull(false)    
    @Column({ type: DataType.INTEGER, field: 'Id'})
    id: number

    @Column({ type: DataType.STRING(400) })
    Name: string    
}


