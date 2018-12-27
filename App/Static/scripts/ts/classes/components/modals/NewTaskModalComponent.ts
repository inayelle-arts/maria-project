import {CompositeComponentBase} from "../base/CompositeComponentBase";

export class NewTaskModalComponent extends CompositeComponentBase
{
	constructor(id: string = 'new-task-modal')
	{
		super(id);
	}
	
	public showModal(callback): void
	{
		const jName = this.JDom.find('#new-task-modal-name');
		const jDescr = this.JDom.find('#new-task-modal-description');
		
		jName.val('');
		jDescr.val('');
		
		const confirmButton = $(this.JDom.find('#new-task-modal-confirm').get(0));
		
		this.JDom.bind('hidden.bs.modal', () =>
		{
			confirmButton.unbind();
		});
		
		confirmButton.bind('click', () =>
		{
			// confirmButton.unbind('click');
			
			const name = jName.val();
			const descr = jDescr.val();
			// @ts-ignore
			this.JDom.modal('hide');
			
			callback(name, descr);
		});
		
		// @ts-ignore
		this.JDom.modal();
	}
}