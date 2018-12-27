export class ResponseResultSet
{
	private _status: string;
	private _message: string;
	private _data: object;
	
	get status(): string
	{
		return this._status;
	}
	
	set status(value: string)
	{
		this._status = value;
	}
	
	get message(): string
	{
		return this._message;
	}
	
	set message(value: string)
	{
		this._message = value;
	}
	
	get data(): object
	{
		return this._data;
	}
	
	set data(value: object)
	{
		this._data = value;
	}
}