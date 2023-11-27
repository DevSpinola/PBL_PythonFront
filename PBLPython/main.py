from api_client import checaColisao, checaMeteoro, checaProjetil
from lancamento import simulacao_animada


print('Bem vindo ao Projeto lançamento Balístico!')
angulo = float(input('Digite um angulo para fazer a simulação: '))
while True:
    resp = int(input('Deseja digitar os dados do meteoro ou utilizar os valores padrões?' +
                     '\n1-Digitar Dados\n2-Valores padrões'+
                     '(Altura= 150m, Distância = 100m, Velocidade= 20m/s)\n'))
    match resp:
        case 1:
            meteoroAltura = int(input('Digite a altura inicial do meteoro: '))
            meteorodistancia = int(input('Digite a distância horizontal do meteoro: '))
            meteoroVelocidade = int(input('Digite a Velocidade inicial do meteoro: '))     
            break
        case 2:     
            meteoroAltura = 150
            meteorodistancia = 100
            meteoroVelocidade = 20
            break
        case _:
            print('Opção inválida!')  
atingiu = False                      
while atingiu is False:         
    projetil = checaProjetil(angulo)       
    meteoro = checaMeteoro(meteoroAltura,meteorodistancia, meteoroVelocidade) 
    colisao = checaColisao(projetil.get('projetilId'), meteoro.get('meteoroId')) 
    print(colisao.get('mensagem'))
    if(colisao.get('colisoes')[0].get('voParaColidir') is None):
        angulo = float(input('Digite um angulo para fazer a simulação: '))
    else: 
        atingiu = True    
        for x in range(len(colisao.get('colisoes'))):
            velocidade_inicial = colisao.get('colisoes')[x].get('voParaColidir')
            anguloRad = projetil.get('anguloRad')
            tempo_total = colisao.get('colisoes')[x].get('tempoColisao')
            intervalo_tempo = tempo_total/100
            distancia_meteoro = meteoro.get('distanciaHorizontal')  # em metros
            altura_meteoro = meteoro.get('alturaInicial')  # em metros
            velocidade_meteoro = meteoro.get('velocidadeMeteoro')  # em metros por segundo
            nome_arquivo = 'colisao' + str(colisao.get('colisoes')[x].get('colisaoId'))
            print(f'Salvando animação...')
            simulacao_animada(velocidade_inicial, anguloRad, tempo_total, intervalo_tempo, distancia_meteoro, altura_meteoro, velocidade_meteoro,nome_arquivo )

