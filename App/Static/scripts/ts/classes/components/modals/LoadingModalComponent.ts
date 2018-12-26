import {CompositeComponentBase} from "../base/CompositeComponentBase";

export class LoadingModalComponent extends CompositeComponentBase
{
	private _isVisible: boolean;
	
	constructor(id: string)
	{
		super(id);
		this._isVisible = false;
	}
	
	public show(): void
	{
		if (this._isVisible)
		{
			return;
		}
		
		super.show();
		this._isVisible = true;
	}
	
	public hide(): void
	{
		if (!this._isVisible)
		{
			return;
		}
		
		super.hide();
		this._isVisible = false;
	}
}