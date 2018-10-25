import { Table, Column, Model, PrimaryKey, AutoIncrement, DataType, AllowNull, ForeignKey, BelongsTo, Scopes } from 'sequelize-typescript';
  
@Table({ tableName: 'Campaign' })
export class Campaign extends Model<Campaign> {
    @PrimaryKey  
    @AutoIncrement  
    @AllowNull(false)    
    @Column({ type: DataType.INTEGER, field: 'Id'})
    id: number

    @Column({ type: DataType.STRING(400) })
    Name: string   
    
   
}

