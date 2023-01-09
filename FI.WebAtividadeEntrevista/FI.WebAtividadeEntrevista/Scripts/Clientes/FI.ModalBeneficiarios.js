
$(document).ready(function () {
	var teste = [{
		Id: 1, Nome: "Teste", Alterar: "TOEME"
	}];
	$('#formCadastro #Beneficiarios').click(function (e) {
		ModalDialog();
	});
	$('#Salvar-Beneficiario').click(function (e) {
		let object = $('#BeneficiarioForm').serialize();
		$.ajax({
			url: urlIncluirBeneficiario,
			type: 'POST',
			data: object,
			success: function (data) {
				console.log(data)
			}
		});
	});

	if (document.getElementById("gridBeneficiarios"))
		$('#gridBeneficiarios').jtable({
			title: 'Clientes',
			paging: true, //Enable paging
			pageSize: 5, //Set page size (default: 10)
			sorting: true, //Enable sorting
			defaultSorting: 'Nome ASC', //Set default sorting
			actions: {
				listAction: urlBeneficiariosList
			},
			fields: {
				Id: {
					title: 'Id',
					width: '50%'
				},
				Nome: {
					title: 'Nome',
					width: '35%'
				},
				Alterar: {
					title: '',
					display: function (data) {
						return '<button onclick="window.location.href=\'' + urlAlteracao + '/' + data.record.Id + '\'" class="btn btn-primary btn-sm">Alterar</button>';
					}
				}
			}
		});

	//Load student list from server
	if (document.getElementById("gridBeneficiarios"))
		$('#gridBeneficiarios').jtable('load');
})

function ModalDialog() {
    var random = Math.random().toString().replace('.', '');
    var texto = '<div id="' + random + '" class="modal fade">                                                               ' +
        '        <div class="modal-dialog">                                                                                 ' +
        '            <div class="modal-content">                                                                            ' +
        '                <div class="modal-header">                                                                         ' +
        '                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>         ' +
        '                    <h4 class="modal-title">Beneficiários</h4>														' +
        '                </div>                                                                                             ' +
		'                <div class="modal-body">                                                                           ' +
		`					<div class="row">
								<div class="col-md-12">
									<form id="BeneficiarioForm">
										<div class="row">
											<div class="col-md-5">
												<div class="form-group>
													<label for="CPF-Beneficiario">CPF: </label>                                      
													<input required="required" type="text" class="form-control" id="CPF-Beneficiario" name="CPF-Beneficiario" placeholder="Ex.: 285.195.450-41" maxlength="14">	 
												</div>                                                                               
											</div>																					 
											<div class="col-md-5">
												<div class="form-group>
													<label for="Nome-Beneficiario">Nome: </label>                                    
													<input required="required" type="text" class="form-control" id="Nome-Beneficiario" name="Nome-Beneficiario" placeholder="Ex.: João Silva" maxlength="255">	 
												</div>                                                                               
											</div>																					 
											<div class="col-md-2">
												<div class="form-group">
													<button type="button" class="btn btn-sm btn-primary" id="Salvar-Beneficiario">Inserir</button>                                   
												</div>                                                                               
											</div>																					 
										</div>																						 
									</form>		
								</div>
							</div>
							<div class="row">
								<div class="col-md-12">
									<table id="gridBeneficiarios" class="table"></table>
								</div>
							</div>`+
        '                </div>                                                                                             ' +
        '                <div class="modal-footer">                                                                         ' +
        '                    <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>             ' +
        '                                                                                                                   ' +
        '                </div>                                                                                             ' +
        '            </div><!-- /.modal-content -->                                                                         ' +
        '  </div><!-- /.modal-dialog -->                                                                                    ' +
        '</div> <!-- /.modal -->                                                                                        ';

    $('body').append(texto);
    $('#' + random).modal('show');
}
